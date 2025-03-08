using OnionDemo.Application.Bases;

namespace OnionDemo.Application.Features.Products.Exceptions;

public class ProductTitleMustNotBeSameException : BaseExceptions
{
    public ProductTitleMustNotBeSameException() : base("Ürün başlığı zaten var!")
    {
    }
}