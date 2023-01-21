using Catalog.Domain.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Persistence.Categories;

public sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        if (builder == null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        builder.Property(e => e.Id)
            .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

        builder.Property(e => e.Name)
            .HasMaxLength(90)
            .IsRequired();
    }
}