using Bookmarks.Application.Wishlists;
using Bookmarks.Application.Wishlists.CreateList;
using BuildingBlocks.Core;
using BuildingBlocks.MassTransit.Contracts;
using BuildingBlocks.Web;
using Microsoft.AspNetCore.Mvc;

namespace Bookmarks.Api.Wishlists.CreateList
{
    public class CreateListController : UserController
    {
        [HttpPost]
        public async Task<IActionResult> AddWishlist([FromForm] CreateListInput input)
        {
            Result<WishlistDto> result = await Mediator.Send(new CreateListCommand.Command(input));

            if (result.Value != null)
            {
                var @event = new WishlistCreated(result.Value.Id);
                HandlePublish(@event);
            }

            return HandleResult(result);
        }
    }
}
