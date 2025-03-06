using OnionDemo.Domain.Common;

namespace OnionDemo.Domain.Entities;

public class Product : EntityBase
{
    public Product()
    {
        
    }

    public Product(string title, string description, decimal price, decimal discount)
    {
        Title = title;
        Description = description;
        Price = price;
        Discount = discount;
    }

    public int BrandId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }

    public Brand Brand { get; set; }
    public ICollection<Category> Categories { get; set; }
}