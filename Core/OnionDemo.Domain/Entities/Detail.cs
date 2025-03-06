using OnionDemo.Domain.Common;

namespace OnionDemo.Domain.Entities;

public class Detail : EntityBase
{
    public Detail()
    {
        
    }
    public Detail(int categoryId, string title, string description)
    {
        CategoryId = categoryId;
        Title = title;
        Description = description;
    }

    public int CategoryId { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }

    public Category Category { get; set; }
}