using FluentValidation;

namespace OnionDemo.Application.Features.Products.Command.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommandRequest>
{
    public CreateProductCommandValidator()
    {
        RuleFor(p => p.Title)
            .NotEmpty()
            .WithName("Başlık");

        RuleFor(p => p.Description)
            .NotEmpty()
            .WithName("Açıklama");

        RuleFor(p => p.BrandId)
            .GreaterThan(0)
            .WithName("Marka");

        RuleFor(p => p.Price)
            .GreaterThan(0)
            .WithName("Fiyat");

        RuleFor(p => p.Discount)
            .GreaterThanOrEqualTo(0)
            .WithName("İndirim");

        RuleFor(p => p.CategoryIds)
            .NotEmpty()
            .Must(categories => categories.Any())
            .WithName("Kategoriler");
    }
}