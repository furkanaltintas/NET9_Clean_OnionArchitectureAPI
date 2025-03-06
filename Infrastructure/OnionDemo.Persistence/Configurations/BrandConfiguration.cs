using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionDemo.Domain.Entities;

namespace OnionDemo.Persistence.Configurations;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.Property(b => b.Name).HasMaxLength(256);

        Faker faker = new("tr");


        Brand brandOne = new()
        {
            Id = 1,
            Name = faker.Commerce.Department(),
            CreatedDate = DateTime.Now,
            IsDeleted = false
        };

        Brand brandTwo = new()
        {
            Id = 2,
            Name = faker.Commerce.Department(),
            CreatedDate = DateTime.Now,
            IsDeleted = false
        };

        Brand brandThree = new()
        {
            Id = 3,
            Name = faker.Commerce.Department(),
            CreatedDate = DateTime.Now,
            IsDeleted = true
        };


        builder.HasData(brandOne, brandTwo, brandThree);
    }
}