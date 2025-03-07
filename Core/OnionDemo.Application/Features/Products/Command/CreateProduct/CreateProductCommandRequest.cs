using MediatR;

namespace OnionDemo.Application.Features.Products.Command.CreateProduct;

public class CreateProductCommandRequest : IRequest<Unit>
{
    public int BrandId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }

    public IList<int> CategoryIds { get; set; }
}