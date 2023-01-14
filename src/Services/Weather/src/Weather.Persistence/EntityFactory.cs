using Weather.Domain;

namespace Weather.Persistence;

public sealed class EntityFactory: IEntityFactory
{
    public Domain.Forecasts.Forecast NewForecast(DateTime date, int temperatureC, string? summary)
    {
        return new Domain.Forecasts.Forecast(Guid.NewGuid(), date, temperatureC, summary);
    }
}