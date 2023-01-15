using BuildingBlocks.MassTransit.Contracts;
using MassTransit;

namespace Weather.Api.Forecasts.CreateForecast;

public class CreateForecastConsumer: IConsumer<WeatherForecastCreated>
{
    private readonly ILogger<CreateForecastConsumer> _logger;
    
    public CreateForecastConsumer(ILogger<CreateForecastConsumer> logger)
    {
        _logger = logger;
    }
    
    public Task Consume(ConsumeContext<WeatherForecastCreated> context)
    {
        _logger.LogInformation("Forecast created with ID: {MessageId}", context.Message.Id);
        return Task.CompletedTask;
    }
}