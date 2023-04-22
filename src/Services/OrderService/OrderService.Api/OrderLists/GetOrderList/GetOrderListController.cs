using OrderService.Application.OrderLists.GetList;
using BuildingBlocks.Web;
using Microsoft.AspNetCore.Mvc;

namespace OrderService.Api.OrderLists.GetOrderList
{
    public class GetOrderListController : UserController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllOrderists()
        {
            return HandleResult(await Mediator.Send(new GetAllListsQuery.Query(false)));
        }

        [HttpGet("{includeBookmarks:bool}")]
        public async Task<IActionResult> GetAllOrderLists(bool includeProducts)
        {
            return HandleResult(await Mediator.Send(new GetAllListsQuery.Query(includeProducts)));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetOrderListById(Guid id)
        {
            return HandleResult(await Mediator.Send(new GetListByIdQuery.Query(id)));
        }
    }
}
