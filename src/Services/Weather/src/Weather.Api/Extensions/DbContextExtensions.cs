using BuildingBlocks.EFCore;
using Microsoft.EntityFrameworkCore;
using Weather.Domain;
using Weather.Domain.Forecasts;
using Weather.Persistence;
using Weather.Persistence.Forecasts;
using DbContext = Weather.Persistence.DbContext;

namespace Weather.Api.Extensions;

public static class DbContextExtensions
{
    public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DbContext>(options =>
        {
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
        });
        services.AddScoped<IForecastRepository, ForecastRepository>();
        services.AddScoped<IEntityFactory, EntityFactory>();

        return services;
    }
}