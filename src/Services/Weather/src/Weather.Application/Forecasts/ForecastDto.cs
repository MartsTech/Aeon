using Weather.Domain.Forecasts;

namespace Weather.Application.Forecasts;

public sealed record ForecastDto
{
    public ForecastDto(IForecast forecast)
    {
        Id = forecast.Id;
        Date = forecast.Date;
        TemperatureC = forecast.TemperatureC;
        TemperatureF = forecast.TemperatureF;
        Summary = forecast.Summary;
    }
    
    public Guid Id { get; }

    public DateTime Date { get; }
    
    public int TemperatureC { get; }
    
    public int TemperatureF { get; }
    
    public string? Summary { get; }
}