using FluentValidation;

namespace OnionDemo.Application.Features.Products.Command.DeleteProduct;

public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommandRequest>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(p => p.Id).GreaterThan(0);
    }
}