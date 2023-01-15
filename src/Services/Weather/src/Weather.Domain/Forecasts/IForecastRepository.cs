namespace Weather.Domain.Forecasts;

public interface IForecastRepository
{
    Task<IList<Forecast>> GetForecasts();
    
    Task CreateForecast(Forecast forecast);
}