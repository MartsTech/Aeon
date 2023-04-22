using OrderService.Application.OrderLists.GetList;
using MediatR;

namespace OrderService.Api.Extensions;

public static class ApplicationExtensions
{
    public static IServiceCollection AddCustomApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(GetAllListsQuery.Handler).Assembly);

        return services;
    }
}