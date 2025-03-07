using OnionDemo.Application.Bases;

namespace OnionDemo.Application.Features.Products.Command;

public class ProductTitleMustNotBeSameException : BaseExceptions
{
    public ProductTitleMustNotBeSameException() : base("Ürün başlığı zaten var!")
    {
    }
}