using ERPServer.Application.Features.Customers.CreateCustomer;
using FluentValidation;

public sealed class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(p => p.TaxNumber).MinimumLength(10).MaximumLength(11);
        RuleFor(p => p.Name).MinimumLength(3);
    }
}