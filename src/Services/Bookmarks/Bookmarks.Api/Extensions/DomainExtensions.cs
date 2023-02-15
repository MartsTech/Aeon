using Bookmarks.Domain;
using Bookmarks.Domain.Bookmarks;
using Bookmarks.Domain.Wishlists;
using Bookmarks.Persistence;
using Bookmarks.Persistence.Bookmarks;
using Bookmarks.Persistence.Wishlists;
using BuildingBlocks.EFCore;
using BuildingBlocks.Web;
using Microsoft.EntityFrameworkCore;

namespace Bookmarks.Api.Extensions;

public static class DomainExtensions
{
    public static IServiceCollection AddCustomDomain(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BookmarksDbContext>(options =>
        {
            var mysql = configuration.GetOptions<MySQLOptions>("MySQLOptions");
            var connection = $"Server={mysql.Host}; Port={mysql.Port}; Database={mysql.Database}; Uid={mysql.User}; Pwd={mysql.Password};";
            options.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 31)), builder =>
            {
                builder.EnableRetryOnFailure();
            });

        });
        
        services.AddScoped<IBookmarkRepository, BookmarkRepository>();
        services.AddScoped<IWishlistRepository, WishlistRepository>();
        services.AddScoped<IEntityFactory, EntityFactory>();

        return services;
    }
}