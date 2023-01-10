using Weather.Domain.Forecasts;

namespace Weather.Application.Forecasts;

public sealed class ForecastDto
{
    public ForecastDto(IForecast forecast)
    {
        Date = forecast.Date;
        TemperatureC = forecast.TemperatureC;
        TemperatureF = forecast.TemperatureF;
        Summary = forecast.Summary;
    }

    public DateOnly Date { get; }
    
    public int TemperatureC { get; }
    
    public int TemperatureF { get; }
    
    public string? Summary { get; }
}