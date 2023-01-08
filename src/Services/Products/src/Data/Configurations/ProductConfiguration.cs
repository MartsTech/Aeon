using BuildingBlocks.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Products.Models;

namespace Products.Data.Configurations;

public class ProductConfiguration: IEntityTypeConfiguration<Products.Models.Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Flight", DbContextBase.DefaultSchema);
        
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id).ValueGeneratedNever();
        
        builder
            .HasOne<Product>()
            .WithMany()
            .HasForeignKey(p => p.Id);
    }
}