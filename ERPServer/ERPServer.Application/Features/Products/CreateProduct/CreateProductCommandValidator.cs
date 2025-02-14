using ERPServer.Application.Features.Products.CreateProduct;
using FluentValidation;

public sealed class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(p => p.TypeValue).GreaterThan(0);
    }
}