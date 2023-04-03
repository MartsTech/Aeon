using BuildingBlocks.Web;
using Catalog.Application.Comments.GetComments;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Comments.GetComments
{
    public class GetCommentsController : UserController
    {
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetCommentById(Guid id)
        {
            return HandleResult(await Mediator.Send(new GetCommentByIdQuery.Query(id)));
        }

        [HttpGet("product/{productId:guid}")]
        public async Task<IActionResult> GetCommentsByProductId(Guid productId)
        {
            return HandleResult(await Mediator.Send(new GetCommentsByProductQuery.Query(productId)));
        }

        [HttpGet("user/{userId:guid}")]
        public async Task<IActionResult> GetCommentsByUserId(Guid userId)
        {
            return HandleResult(await Mediator.Send(new GetCommentsByUserQuery.Query(userId)));
        }
    }
}
