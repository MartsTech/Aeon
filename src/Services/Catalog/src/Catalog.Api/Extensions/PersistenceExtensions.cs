using BuildingBlocks.EFCore;
using Catalog.Persistence;

namespace Catalog.Api.Extensions;

public static class PersistenceExtensions
{
    public static IServiceCollection AddCustomPersistence(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}