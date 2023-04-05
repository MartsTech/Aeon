using BuildingBlocks.Core;
using BuildingBlocks.MassTransit.Contracts;
using BuildingBlocks.Web;
using Catalog.Application.Comments.DeleteUpvote;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Comments.DeleteUpvote;

public class DeleteUpvoteController : UserController
{
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteUpvote(Guid id)
    {
        Result<string> result = await Mediator.Send(new DeleteUpvoteCommand.Command(id));

        if (result.IsSuccess)
        {
            var @event = new UpvoteDeleted(id);
            HandlePublish(@event);
        }

        return HandleResult(result);
    }
}