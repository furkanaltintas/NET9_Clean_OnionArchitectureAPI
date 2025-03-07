using OnionDemo.Domain.Common;

namespace OnionDemo.Domain.Entities;

public class ProductCategory : IEntityBase
{
    public ProductCategory()
    {
        
    }

    public ProductCategory(int productId, int categoryId)
    {
        ProductId = productId;
        CategoryId = categoryId;
    }

    public int ProductId { get; set; }
    public int CategoryId { get; set; }

    public Product Product { get; set; }
    public Category Category { get; set; }
}