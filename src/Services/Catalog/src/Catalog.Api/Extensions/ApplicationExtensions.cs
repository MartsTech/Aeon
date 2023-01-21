using Catalog.Application.Products.GetProducts;
using MediatR;

namespace Catalog.Api.Extensions;

public static class ApplicationExtensions
{
    public static IServiceCollection AddCustomApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(GetAllProductsQuery.Handler).Assembly);

        return services;
    }
}