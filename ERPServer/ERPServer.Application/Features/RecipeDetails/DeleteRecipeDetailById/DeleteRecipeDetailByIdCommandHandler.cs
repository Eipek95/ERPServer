﻿using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.RecipeDetails.DeleteRecipeDetailById
{
    internal sealed class DeleteRecipeDetailByIdCommandHandler(IRecipeDetailRepository recipeDetailRepository,IUnitOfWork unitOfWork) : IRequestHandler<DeleteRecipeDetailByIdCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteRecipeDetailByIdCommand request, CancellationToken cancellationToken)
        {
            RecipeDetail recipeDetail = await recipeDetailRepository.GetByExpressionAsync(x => x.Id == request.Id,cancellationToken);
            if (recipeDetail is null)
            {
                return Result<string>.Failure("Reçetede bu Ürün bulunamadı.");
            }
            recipeDetailRepository.Delete(recipeDetail);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return "Ürün reçeteden başarıyla silindi.";
        }
    }
}
