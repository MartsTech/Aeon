namespace Weather.Domain.Forecasts;

public interface IForecastRepository
{
    Task<IList<Forecast>> GetForecasts();
}