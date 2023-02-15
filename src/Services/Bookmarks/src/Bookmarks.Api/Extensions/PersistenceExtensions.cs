using Bookmarks.Persistence;
using BuildingBlocks.EFCore;

namespace Bookmarks.Api.Extensions;

public static class PersistenceExtensions
{
    public static IServiceCollection AddCustomPersistence(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}