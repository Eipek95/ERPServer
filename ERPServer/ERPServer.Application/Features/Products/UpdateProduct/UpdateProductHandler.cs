using AutoMapper;
using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace ERPServer.Application.Features.Products.UpdateProduct
{
    internal sealed class UpdateProductHandler(
        IProductRepository productRepository, 
        IUnitOfWork unitOfWork, 
        IMapper mapper) : IRequestHandler<UpdateProductCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = await productRepository.GetByExpressionWithTrackingAsync(p=>p.Id==request.Id,cancellationToken);
            if (product is null)
            {
                return Result<string>.Failure("Ürün Bulunamadı");
            }

            if (product.Name!=request.Name)
            {
                bool isProductExists = await productRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);

                if (isProductExists)
                {
                    return Result<string>.Failure("Ürün daha önceden kaydedilmiş");
                }
            }

            mapper.Map(request,product);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Ürün Başarıyla Güncellendi";
        }
    }
}
