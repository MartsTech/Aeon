﻿namespace Weather.Domain.Forecasts;

public interface IForecast
{
    public Guid Id { get; }
    
    public DateOnly Date { get; }

    public int TemperatureC { get; }

    public int TemperatureF { get; }

    public string? Summary { get; }
}