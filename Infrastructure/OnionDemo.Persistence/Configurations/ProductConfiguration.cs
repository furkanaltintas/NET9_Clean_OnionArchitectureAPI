using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionDemo.Domain.Entities;

namespace OnionDemo.Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        Faker faker = new("tr");

        Product productOne = new()
        {
            Id = 1,
            BrandId = 1,
            Title = faker.Commerce.ProductName(),
            Description = faker.Commerce.ProductDescription(),
            Price = faker.Finance.Amount(10, 1000),
            Discount = faker.Random.Decimal(0, 10),
            CreatedDate = DateTime.Now,
            IsDeleted = false
        };

        Product productTwo = new()
        {
            Id = 2,
            BrandId = 3,
            Title = faker.Commerce.ProductName(),
            Description = faker.Commerce.ProductDescription(),
            Price = faker.Finance.Amount(10, 1000),
            Discount = faker.Random.Decimal(0, 10),
            CreatedDate = DateTime.Now,
            IsDeleted = false
        };


        builder.HasData(productOne, productTwo);
    }
}