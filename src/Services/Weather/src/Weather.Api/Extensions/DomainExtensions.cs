using BuildingBlocks.EFCore;
using BuildingBlocks.Web;
using Microsoft.EntityFrameworkCore;
using Weather.Domain;
using Weather.Domain.Forecasts;
using Weather.Persistence;
using Weather.Persistence.Forecasts;
using DbContext = Weather.Persistence.DbContext;

namespace Weather.Api.Extensions;

public static class DomainExtensions
{
    public static IServiceCollection AddCustomDomain(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DbContext>(options =>
        {
            var mysql = configuration.GetOptions<MySQLOptions>("MySQLOptions");
            var connection = $"Server={mysql.Host};Port={mysql.Port};User Id={mysql.User};Password={mysql.Password};Database={mysql.Database};";
            options.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 31)));
        });
        
        services.AddScoped<IForecastRepository, ForecastRepository>();
        services.AddScoped<IEntityFactory, EntityFactory>();

        return services;
    }
}