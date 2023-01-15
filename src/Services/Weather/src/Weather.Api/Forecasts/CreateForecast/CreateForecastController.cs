using BuildingBlocks.MassTransit.Contracts;
using BuildingBlocks.Web;
using Microsoft.AspNetCore.Mvc;
using Weather.Application.Forecasts;
using Weather.Application.Forecasts.CreateForecast;

namespace Weather.Api.Forecasts.CreateForecast;

public class WeatherForecastController : UserController
{
    [HttpPost]
    public async Task<IActionResult> CreateForecast(
        [FromForm] CreateForecastInput input)
    {
        var result = await Mediator.Send(new CreateForecastCommand.Command(input));

        if (result.Value != null)
        {
            var @event = new WeatherForecastCreated(result.Value.Id);
            HandlePublish(@event);
        }

        return HandleResult(result);
    }
}