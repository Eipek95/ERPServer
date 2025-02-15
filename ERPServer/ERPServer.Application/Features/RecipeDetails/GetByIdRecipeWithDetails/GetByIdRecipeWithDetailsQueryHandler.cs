using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace ERPServer.Application.Features.RecipeDetails.GetByIdRecipeWithDetails
{
    internal sealed class GetByIdRecipeWithDetailsQueryHandler(IRecipeRepository recipeRepository) : IRequestHandler<GetByIdRecipeWithDetailsQuery, Result<Recipe>>
    {
        public async Task<Result<Recipe>> Handle(GetByIdRecipeWithDetailsQuery request, CancellationToken cancellationToken)
        {
            Recipe? recipe = await recipeRepository.Where(x => x.Id == request.RecipeId)
                .Include(p => p.Product)
                .Include(p => p.Details!.OrderBy(p=>p.Product!.Name))
                .ThenInclude(p => p.Product)
                .FirstOrDefaultAsync(cancellationToken);

            if (recipe is null) return Result<Recipe>.Failure("Ürüne ait reçete bulunamadı.");

            return recipe;
        }
    }
}
