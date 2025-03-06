using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionDemo.Domain.Entities;

namespace OnionDemo.Persistence.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        Category categoryOne = new()
        {
            Id = 1,
            Name = "Electric",
            Priorty = 1,
            ParentId = 0,
            CreatedDate = DateTime.Now,
            IsDeleted = false
        };

        Category categoryTwo = new()
        {
            Id = 2,
            Name = "Fashion",
            Priorty = 2,
            ParentId = 0,
            CreatedDate = DateTime.Now,
            IsDeleted = false
        };

        Category parentOne = new()
        {
            Id = 3,
            Name = "Computer",
            Priorty = 1,
            ParentId = 1,
            CreatedDate = DateTime.Now,
            IsDeleted = false
        };

        Category parentTwo = new()
        {
            Id = 4,
            Name = "Woman",
            Priorty = 1,
            ParentId = 2,
            CreatedDate = DateTime.Now,
            IsDeleted = false
        };


        builder.HasData(categoryOne, categoryTwo, parentOne, parentTwo);
    }
}