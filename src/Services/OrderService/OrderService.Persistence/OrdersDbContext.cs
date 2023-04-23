using BuildingBlocks.EFCore;
using Catalog.Domain.Categories;
using Catalog.Domain.Comments;
using Catalog.Domain.Products;
using OrderService.Domain.Orders;
using OrderService.Domain.OrderLists;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using Catalog.Persistence.Products;

namespace OrderService.Persistence;

public sealed class OrdersDbContext : DbContextBase
{
    public OrdersDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderList> OrderLists { get; set; }
   

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        if (modelBuilder is null)
        {
            throw new ArgumentNullException(nameof(modelBuilder));
        }

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrdersDbContext).Assembly);

        ProductSeeder.SeedData(modelBuilder);
    }
}