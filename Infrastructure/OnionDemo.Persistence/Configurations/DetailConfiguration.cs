using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionDemo.Domain.Entities;

namespace OnionDemo.Persistence.Configurations;

public class DetailConfiguration : IEntityTypeConfiguration<Detail>
{
    public void Configure(EntityTypeBuilder<Detail> builder)
    {
        Faker faker = new("tr");

        Detail detailOne = new()
        {
            Id = 1,
            CategoryId = 1,
            Title = faker.Lorem.Sentence(1),
            Description = faker.Lorem.Sentence(5),
            CreatedDate = DateTime.Now,
            IsDeleted = false
        };

        Detail detailTwo = new()
        {
            Id = 2,
            CategoryId = 3,
            Title = faker.Lorem.Sentence(2),
            Description = faker.Lorem.Sentence(5),
            CreatedDate = DateTime.Now,
            IsDeleted = true
        };

        Detail detailThree = new()
        {
            Id = 3,
            CategoryId = 4,
            Title = faker.Lorem.Sentence(1),
            Description = faker.Lorem.Sentence(5),
            CreatedDate = DateTime.Now,
            IsDeleted = false
        };


        builder.HasData(detailOne, detailTwo, detailThree);
    }
}