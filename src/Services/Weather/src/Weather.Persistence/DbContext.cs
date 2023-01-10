using BuildingBlocks.EFCore;
using Microsoft.EntityFrameworkCore;

namespace Weather.Persistence;

public sealed class DbContext: DbContextBase
{
    public DbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Domain.Forecasts.Forecast> Forecasts { get; set; }
}