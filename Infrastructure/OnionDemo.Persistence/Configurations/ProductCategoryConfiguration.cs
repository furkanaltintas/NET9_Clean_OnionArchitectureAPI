using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionDemo.Domain.Entities;

namespace OnionDemo.Persistence.Configurations;

public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.HasKey(p => new { p.ProductId, p.CategoryId });

        builder.HasOne(p => p.Product)
            .WithMany(p => p.ProductCategories)
            .HasForeignKey(p => p.ProductId).OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(c => c.Category)
            .WithMany(c => c.ProductCategories)
            .HasForeignKey(c => c.CategoryId).OnDelete(DeleteBehavior.Cascade);
    }
}