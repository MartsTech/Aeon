namespace Weather.Domain.Forecasts;

public class Forecast : IForecast
{
    public Forecast(Guid id, DateOnly date, int temperatureC, string? summary)
    {
        Id = id;
        Date = date;
        TemperatureC = temperatureC;
        Summary = summary;
    }
    
    public Guid Id { get; }

    public DateOnly Date { get; }
    
    public int TemperatureC { get; }
    
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    
    public string? Summary { get; }
}