using Bookmarks.Application.Bookmarks;
using Bookmarks.Application.Bookmarks.UpdateBookmark;
using BuildingBlocks.Core;
using BuildingBlocks.MassTransit.Contracts;
using BuildingBlocks.Web;
using Microsoft.AspNetCore.Mvc;

namespace Bookmarks.Api.Bookmarks.UpdateBookmark
{
    public class UpdateBookmarkController : UserController
    {
        [HttpPut]
        public async Task<IActionResult> UpdateBookmark([FromForm] UpdateBookmarkInput input)
        {
            Result<bool> result = await Mediator.Send(new UpdateBookmarkCommand.Command(input));

            if (result.Value)
            {
                var @event = new BookmarkUpdated(input.Id);
                HandlePublish(@event);
            }

            return HandleResult(result);
        }
    }
}
