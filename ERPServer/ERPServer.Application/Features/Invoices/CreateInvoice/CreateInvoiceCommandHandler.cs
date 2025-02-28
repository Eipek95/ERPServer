﻿using AutoMapper;
using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Invoices.CreateInvoice
{
    internal sealed class CreateInvoiceCommandHandler(IInvoiceRepository invoiceRepository
        , IUnitOfWork unitOfWork,
        IMapper mapper,
        IStockMovementRepository stockMovementRepository) : IRequestHandler<CreateInvoiceCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {

            Invoice invoice = mapper.Map<Invoice>(request);

            if (invoice.Details is not null)
            {
                List<StockMovement> movements = new();
                foreach (var item in invoice.Details)
                {
                    StockMovement movement = new()
                    {
                        InvoiceId = invoice.Id,
                        NumberOfEntries = request.TypeValue == 1 ? item.Quantity : 0,
                        NumberOfOutputs = request.TypeValue == 2 ? item.Quantity : 0,
                        DepotId = item.DepotId,
                        Price = item.Price,
                        ProductId = item.ProductId,
                    };

                    movements.Add(movement);
                }

                await stockMovementRepository.AddRangeAsync(movements, cancellationToken);
            }

            await invoiceRepository.AddAsync(invoice, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Fatura Başarıyla Oluşturuldu";
        }
    }
}
