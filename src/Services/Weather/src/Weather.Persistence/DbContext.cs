using BuildingBlocks.EFCore;
using Microsoft.EntityFrameworkCore;
using Weather.Persistence.Forecasts;

namespace Weather.Persistence;

public sealed class DbContext: DbContextBase
{
    public DbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Domain.Forecasts.Forecast> Forecasts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        if (modelBuilder is null)
        {
            throw new ArgumentNullException(nameof(modelBuilder));
        }
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DbContext).Assembly);

        ForecastSeeder.SeedData(modelBuilder);
    }
}