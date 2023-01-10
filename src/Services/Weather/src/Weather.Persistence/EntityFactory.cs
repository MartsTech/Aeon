using Weather.Domain;

namespace Weather.Persistence;

public sealed class EntityFactory: IEntityFactory
{
    public Domain.Forecasts.Forecast NewForecast(DateOnly date, int temperatureC, string? summary)
    {
        return new Domain.Forecasts.Forecast(date, temperatureC, summary);
    }
}