using Weather.Domain.Forecasts;

namespace Weather.Domain;

public interface IEntityFactory
{
    Forecast NewForecast(DateOnly date, int temperatureC, string? summary);
}