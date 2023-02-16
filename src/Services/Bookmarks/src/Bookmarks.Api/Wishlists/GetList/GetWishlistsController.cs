using Bookmarks.Application.Wishlists.GetList;
using BuildingBlocks.Web;
using Microsoft.AspNetCore.Mvc;

namespace Bookmarks.Api.Wishlists.GetList
{
    public class GetWishlistsController : UserController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllWishlists()
        {
            return HandleResult(await Mediator.Send(new GetAllListsQuery.Query(false)));
        }

        [HttpGet("{includeBookmarks:bool}")]
        public async Task<IActionResult> GetAllWishlists(bool includeBookmarks)
        {
            return HandleResult(await Mediator.Send(new GetAllListsQuery.Query(includeBookmarks)));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetWishlistById(Guid id)
        {
            return HandleResult(await Mediator.Send(new GetListByIdQuery.Query(id)));
        }
    }
}