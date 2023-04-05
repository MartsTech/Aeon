using BuildingBlocks.Core;
using BuildingBlocks.MassTransit.Contracts;
using BuildingBlocks.Web;
using Catalog.Application.Ratings;
using Catalog.Application.Ratings.UpdateRating;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Ratings.UpdateRating;

public class UpdateRatingController : UserController
{
    [HttpPut]
    public async Task<IActionResult> UpdateRating([FromForm] UpdateRatingInput input)
    {
        Result<RatingDto> result = await Mediator.Send(new UpdateRatingCommand.Command(input));

        if (result.Value != null)
        {
            var @event = new RatingUpdated(result.Value.Id);
            HandlePublish(@event);
        }

        return HandleResult(result);
    }
}