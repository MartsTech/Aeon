using BuildingBlocks.Core;
using BuildingBlocks.MassTransit.Contracts;
using BuildingBlocks.Web;
using Catalog.Application.Comments.DeleteComment;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Comments.DeleteComment;

public class DeleteCommentController : UserController
{
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteComment(Guid id)
    {
        Result<string> result = await Mediator.Send(new DeleteCommentCommand.Command(id));

        if (result.IsSuccess)
        {
            var @event = new CommentDeleted(id);
            HandlePublish(@event);
        }

        return HandleResult(result);
    }
}