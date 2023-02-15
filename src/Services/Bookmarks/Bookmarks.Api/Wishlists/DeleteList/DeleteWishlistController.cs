using Bookmarks.Application.Wishlists.DeleteList;
using BuildingBlocks.Core;
using BuildingBlocks.MassTransit.Contracts;
using BuildingBlocks.Web;
using Microsoft.AspNetCore.Mvc;

namespace Bookmarks.Api.Wishlists.DeleteList
{
    public class DeleteWishlistController : UserController
    {
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteWishlist(Guid id)
        {
            Result<string> result = await Mediator.Send(new DeleteListCommand.Command(id));

            if (result.IsSuccess)
            {
                var @event = new WishlistDeleted(id);
                HandlePublish(@event);
            }

            return HandleResult(result);
        }
    }
}
