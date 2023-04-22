using OrderService.Application.OrderLists.GetOrderList;
using BuildingBlocks.Web;
using Microsoft.AspNetCore.Mvc;

namespace OrderService.Api.OrderLists.GetOrderList
{
    public class GetWishlistsController : UserController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllOrderists()
        {
            return HandleResult(await Mediator.Send(new GetAllOrderListsQuery.Query(false)));
        }

        [HttpGet("{includeBookmarks:bool}")]
        public async Task<IActionResult> GetAllWishlists(bool includeProducts)
        {
            return HandleResult(await Mediator.Send(new GetAllOrderListsQuery.Query(includeProducts)));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetOrderListById(Guid id)
        {
            return HandleResult(await Mediator.Send(new GetOrderListByIdQuery.Query(id)));
        }
    }
}
