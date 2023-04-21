using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

using BuildingBlocks.EFCore;
using ShoppingCart.Domain;
using ShoppingCart.Domain.Products;
using ShoppingCart.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Persistence;

public sealed class ShoppingCartDbContext : DbContextBase
{
    public ShoppingCartDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        if (modelBuilder is null)
        {
            throw new ArgumentNullException(nameof(modelBuilder));
        }

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShoppingCartDbContext).Assembly);

        ProductSeeder.SeedData(modelBuilder);
    }
}

