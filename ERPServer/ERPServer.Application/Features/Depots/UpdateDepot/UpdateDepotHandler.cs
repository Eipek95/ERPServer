using AutoMapper;
using ERPServer.Application.Features.Depots.UpdateDepot;
using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Depots.UpdateDepot
{
    internal sealed class UpdateDepotHandler(IDepotRepository depotRepository,IMapper mapper,IUnitOfWork unitOfWork) : IRequestHandler<UpdateDepotCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateDepotCommand request, CancellationToken cancellationToken)
        {
            Depot depot = await depotRepository.GetByExpressionWithTrackingAsync(p => p.Id == request.Id, cancellationToken);

            if (depot is null) return Result<string>.Failure("Depo Bulunamadı");

            mapper.Map(request,depot);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return "Depo Bilgileri Başarıyla Güncellendi";
        }
    }
}
