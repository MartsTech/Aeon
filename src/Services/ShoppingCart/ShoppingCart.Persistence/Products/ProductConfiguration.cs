using ShoppingCart.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Persistence.Products;

public sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        if (builder == null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        builder.Property(e => e.Id)
            .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

        builder.Property(e => e.Title)
            .IsRequired()
            .HasMaxLength(90);

        builder.Property(e => e.Price)
            .IsRequired();

        builder.Property(e => e.Description)
            .HasMaxLength(255);

        builder.HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
            .IsRequired();

        builder.Property(e => e.Quantity)
            .IsRequired();
    }
}