using BuildingBlocks.Core;
using BuildingBlocks.MassTransit.Contracts;
using BuildingBlocks.Web;
using Catalog.Application.Comments;
using Catalog.Application.Comments.AddUpvote;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Comments.AddUpvote
{
    public class AddUpvoteController:UserController
    {
        [HttpPost]
        public async Task<IActionResult> AddUpvote([FromForm] AddUpvoteInput input)
        {
            Result<UpvoteDto> result = await Mediator.Send(new AddUpvoteCommand.Command(input));

            if (result.Value != null)
            {
                var @event = new UpvoteCreated(result.Value.Id);
                HandlePublish(@event);
            }

            return HandleResult(result);
        }
    }
}
