using FluentValidation;

namespace Saltro.Application.Commands.Products;

public sealed class CreateProductValidator : AbstractValidator<CreateProduct>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.Payload.Name)
            .Must(i => !string.IsNullOrEmpty(i) && i.Length >= 3 && i.Length <= 100)
            .WithMessage("Name should be atleast 3 to 100 characters");

        RuleFor(x => x.Payload.Price)
            .GreaterThan(0)
            .WithMessage("Price should be more than 0");

        RuleFor(x => x.Payload.MaxQuantity)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Max quantity should be more than 0");

        RuleFor(x => x.Payload.ProductNo)
            .MaximumLength(50);

        RuleFor(x => x.Payload.SellPrice)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.Payload.SellVAT)
            .InclusiveBetween(0, 100);
    }
}
