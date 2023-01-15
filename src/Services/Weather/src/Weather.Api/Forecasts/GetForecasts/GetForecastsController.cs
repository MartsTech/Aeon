using BuildingBlocks.Web;
using Microsoft.AspNetCore.Mvc;
using Weather.Application.Forecasts.GetForecasts;

namespace Weather.Api.Forecasts.GetForecasts;

public class WeatherForecastController : UserController
{
    [HttpGet]
    public async Task<IActionResult> GetForecasts()
    {
        return HandleResult(await Mediator.Send(new GetForecastsQuery.Query()));
    }
}