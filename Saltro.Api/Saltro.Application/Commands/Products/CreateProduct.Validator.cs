using FluentValidation;
using Saltro.Application.Payloads;

namespace Saltro.Application.Commands.Products;

internal sealed class CreateProductValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .Length(3, 100);

        RuleFor(x => x.Price)
            .GreaterThan(0);

        RuleFor(x => x.MaxQuantity)
            .GreaterThan(0);

        RuleFor(x => x.ProductNo)
            .MaximumLength(50);

        RuleFor(x => x.SellPrice)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.SellVAT)
            .InclusiveBetween(0, 100);
    }
}
