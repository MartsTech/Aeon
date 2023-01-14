using Weather.Domain.Forecasts;

namespace Weather.Domain;

public interface IEntityFactory
{
    Forecast NewForecast(DateTime date, int temperatureC, string? summary);
}