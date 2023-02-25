using BuildingBlocks.EFCore;
using Catalog.Domain.Categories;
using Catalog.Domain.Products;
using Catalog.Persistence.Products;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Persistence;

public sealed class CatalogDbContext : DbContextBase
{
    public CatalogDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        if (modelBuilder is null)
        {
            throw new ArgumentNullException(nameof(modelBuilder));
        }

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogDbContext).Assembly);

        ProductSeeder.SeedData(modelBuilder);
    }
}