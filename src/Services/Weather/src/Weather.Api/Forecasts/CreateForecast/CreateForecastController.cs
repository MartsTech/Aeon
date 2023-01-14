using BuildingBlocks.Web;
using Microsoft.AspNetCore.Mvc;
using Weather.Application.Forecasts.CreateForecast;

namespace Weather.Api.Forecasts.CreateForecast;

public class WeatherForecastController : UserController
{
    [HttpPost]
    public async Task<IActionResult> CreateForecast(
        [FromForm] CreateForecastInput input)
    {
        return HandleResult(await Mediator.Send(new CreateForecastCommand.Command(input)));
    }
}