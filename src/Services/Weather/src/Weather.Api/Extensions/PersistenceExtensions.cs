using BuildingBlocks.EFCore;
using Weather.Persistence;

namespace Weather.Api.Extensions;

public static class PersistenceExtensions
{
    public static IServiceCollection AddCustomPersistence(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}