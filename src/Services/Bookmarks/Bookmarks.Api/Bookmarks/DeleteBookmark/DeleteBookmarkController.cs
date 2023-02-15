using Bookmarks.Application.Bookmarks.DeleteBookmark;
using BuildingBlocks.Core;
using BuildingBlocks.MassTransit.Contracts;
using BuildingBlocks.Web;
using Microsoft.AspNetCore.Mvc;

namespace Bookmarks.Api.Bookmarks.DeleteBookmark
{
    public class DeleteBookmarkController : UserController
    {
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteBookmark(Guid id)
        {
            Result<string> result = await Mediator.Send(new DeleteBookmarkCommand.Command(id));

            if (result.IsSuccess)
            {
                var @event = new BookmarkDeleted(id);
                HandlePublish(@event);
            }

            return HandleResult(result);
        }
    }
}