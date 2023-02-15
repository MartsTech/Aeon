using Bookmarks.Application.Bookmarks.GetBookmark;
using BuildingBlocks.Web;
using Microsoft.AspNetCore.Mvc;

namespace Bookmarks.Api.Bookmarks.GetBookmark
{
    public class GetBookmarksController : UserController
    {
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetBookmarkById(Guid id)
        {
            return HandleResult(await Mediator.Send(new GetBookmarkByIdQuery.Query(id)));
        }
    }
}