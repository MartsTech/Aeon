using BuildingBlocks.Web;
using Catalog.Application.Comments.GetUpvotes;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Comments.GetUpvotes;

public class GetUpvotesController : UserController
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetUpvoteById(Guid id)
    {
        return HandleResult(await Mediator.Send(new GetUpvoteByIdQuery.Query(id)));
    }

    [HttpGet("comment/{commentId:guid}")]
    public async Task<IActionResult> GetUpvotesOfComment(Guid commentId)
    {
        return HandleResult(await Mediator.Send(new GetUpvotesOfCommentQuery.Query(commentId)));
    }
}