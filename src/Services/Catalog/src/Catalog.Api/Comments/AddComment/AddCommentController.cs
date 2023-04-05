using BuildingBlocks.Core;
using BuildingBlocks.MassTransit.Contracts;
using BuildingBlocks.Web;
using Catalog.Application.Comments;
using Catalog.Application.Comments.AddComment;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Comments.AddComment;

public class AddCommentController : UserController
{
    [HttpPost]
    public async Task<IActionResult> AddComment([FromForm] AddCommentInput input)
    {
        Result<CommentDto> result = await Mediator.Send(new AddCommentCommand.Command(input));

        if (result.Value != null)
        {
            var @event = new CommentCreated(result.Value.Id);
            HandlePublish(@event);
        }

        return HandleResult(result);
    }
}