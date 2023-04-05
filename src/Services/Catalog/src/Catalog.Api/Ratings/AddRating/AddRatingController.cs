using BuildingBlocks.Core;
using BuildingBlocks.MassTransit.Contracts;
using BuildingBlocks.Web;
using Catalog.Application.Ratings;
using Catalog.Application.Ratings.AddRating;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Ratings.AddRating;

public class AddRatingController : UserController
{
    [HttpPost]
    public async Task<IActionResult> AddRating([FromForm] AddRatingInput input)
    {
        Result<RatingDto> result = await Mediator.Send(new AddRatingCommand.Command(input));

        if (result.Value != null)
        {
            var @event = new RatingCreated(result.Value.Id);
            HandlePublish(@event);
        }

        return HandleResult(result);
    }
}