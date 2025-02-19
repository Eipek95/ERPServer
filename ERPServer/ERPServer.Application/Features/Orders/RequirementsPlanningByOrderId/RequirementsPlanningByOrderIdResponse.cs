using ERPServer.Domain.Dtos;

namespace ERPServer.Application.Features.Orders.RequirementsPlanningByOrderId
{
    public sealed record RequirementsPlanningByOrderIdResponse(DateOnly Date,String Title,List<ProductDto> Products);
}