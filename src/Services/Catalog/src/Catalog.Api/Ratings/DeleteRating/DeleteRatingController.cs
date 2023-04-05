using BuildingBlocks.Core;
using BuildingBlocks.MassTransit.Contracts;
using BuildingBlocks.Web;
using Catalog.Application.Ratings.DeleteRating;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Ratings.DeleteRating;

public class DeleteRatingController : UserController
{
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteRating(Guid id)
    {
        Result<string> result = await Mediator.Send(new DeleteRatingCommand.Command(id));

        if (result.IsSuccess)
        {
            var @event = new RatingDeleted(id);
            HandlePublish(@event);
        }

        return HandleResult(result);
    }
}