using System.ComponentModel.DataAnnotations;

namespace Weather.Application.Forecasts.CreateForecast;

public sealed record CreateForecastInput
{
    [Required]
    public DateOnly Date { get; set; }

    [Required]
    public int TemperatureC { get; set; }
    
    [Required]
    public string? Summary { get; set; } = string.Empty;
}