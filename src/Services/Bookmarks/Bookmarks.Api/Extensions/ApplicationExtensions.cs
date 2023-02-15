using Bookmarks.Application.Wishlists.GetList;
using MediatR;

namespace Bookmarks.Api.Extensions;

public static class ApplicationExtensions
{
    public static IServiceCollection AddCustomApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(GetAllListsQuery.Handler).Assembly);

        return services;
    }
}