using System.ComponentModel.DataAnnotations;

namespace Weather.Application.Forecasts.CreateForecast;

public sealed record CreateForecastInput
{
    [Required]
    public DateTime Date { get; set; }

    [Required]
    public int TemperatureC { get; set; }
    
    public string? Summary { get; set; } = string.Empty;
}