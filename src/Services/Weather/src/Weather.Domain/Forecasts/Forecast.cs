namespace Weather.Domain.Forecasts;

public class Forecast : IForecast
{
    public Forecast(DateOnly date, int temperatureC, string? summary)
    {
        Date = date;
        TemperatureC = temperatureC;
        Summary = summary;
    }

    public DateOnly Date { get; }
    
    public int TemperatureC { get; }
    
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    
    public string? Summary { get; }
}