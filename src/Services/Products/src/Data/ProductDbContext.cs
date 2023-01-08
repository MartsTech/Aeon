using BuildingBlocks.EFCore;
using BuildingBlocks.Web;
using Microsoft.EntityFrameworkCore;

namespace Products.Data;

public class ProductDbContext: DbContextBase
{
    public ProductDbContext(DbContextOptions options, ICurrentUserProvider currentUserProvider) : base(options, currentUserProvider)
    {
    }
    
    public DbSet<Products.Models.Product> Products => Set<Products.Models.Product>();
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ProductRoot).Assembly);
    }
}