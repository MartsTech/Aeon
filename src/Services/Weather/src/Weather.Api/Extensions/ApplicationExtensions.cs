using MediatR;
using Weather.Application.Forecasts.GetForecasts;

namespace Weather.Api.Extensions;

public static class ApplicationExtensions
{
    public static IServiceCollection AddCustomApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(GetForecastsQuery.Handler).Assembly);

        return services;
    }
}