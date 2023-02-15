using Bookmarks.Application.Bookmarks;
using Bookmarks.Application.Bookmarks.AddBookmark;
using BuildingBlocks.Core;
using BuildingBlocks.MassTransit.Contracts;
using BuildingBlocks.Web;
using Microsoft.AspNetCore.Mvc;

namespace Bookmarks.Api.Bookmarks.AddBookmark
{
    public class AddBookmarkController : UserController
    {
        [HttpPost]
        public async Task<IActionResult> AddBookmark([FromForm] AddBookmarkInput input)
        {
            Result<BookmarkDto> result = await Mediator.Send(new AddBookmarkCommand.Command(input));

            if (result.Value != null)
            {
                var @event = new BookmarkCreated(result.Value.Id);
                HandlePublish(@event);
            }

            return HandleResult(result);
        }
    }
}
