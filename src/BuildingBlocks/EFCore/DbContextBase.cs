using Microsoft.EntityFrameworkCore;

namespace BuildingBlocks.EFCore;

public abstract class DbContextBase: DbContext, IDbContext
{
    protected DbContextBase(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        if (modelBuilder is null)
        {
            throw new ArgumentNullException(nameof(modelBuilder));
        }
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DbContextBase).Assembly);
    }
}