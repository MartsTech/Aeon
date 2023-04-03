using BuildingBlocks.Core;
using BuildingBlocks.MassTransit.Contracts;
using BuildingBlocks.Web;
using Catalog.Application.Comments;
using Catalog.Application.Comments.UpdateComment;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Comments.UpdateComment
{
    public class UpdateCommentController : UserController
    {
        [HttpPut]
        public async Task<IActionResult> UpdateComment([FromForm] UpdateCommentInput input)
        {
            Result<CommentDto> result = await Mediator.Send(new UpdateCommentCommand.Command(input));

            if (result.Value != null)
            {
                var @event = new CommentUpdated(result.Value.Id);
                HandlePublish(@event);
            }

            return HandleResult(result);
        }
    }
}
