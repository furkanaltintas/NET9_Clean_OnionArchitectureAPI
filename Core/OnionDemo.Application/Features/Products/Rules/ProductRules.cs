using OnionDemo.Application.Bases;
using OnionDemo.Domain.Entities;

namespace OnionDemo.Application.Features.Products.Rules;

public class ProductRules : BaseRules
{

    public Task ProductTitleMustNotBeSame(IList<Product> products, string requestTitle)
    {
        if (products.Any(p => p.Title == requestTitle)) throw new ProductTitleMustNotBeSameException();
        return Task.CompletedTask;
    }
}