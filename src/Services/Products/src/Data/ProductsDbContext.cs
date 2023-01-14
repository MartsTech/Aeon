using BuildingBlocks.EFCore;
using Microsoft.EntityFrameworkCore;
using Products.Data.Entities;

namespace Products.Data
{
    public class ProductsDbContext : DbContextBase
    {
        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}