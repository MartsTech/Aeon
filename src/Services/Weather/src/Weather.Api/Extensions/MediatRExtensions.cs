using MediatR;
using Weather.Application.Forecasts.GetForecasts;

namespace Weather.Api.Extensions;

public static class MediatRExtensions
{
    public static IServiceCollection AddCustomMediatR(this IServiceCollection services)
    {
        services.AddMediatR(typeof(GetForecastsQuery.Handler).Assembly);

        return services;
    }
}