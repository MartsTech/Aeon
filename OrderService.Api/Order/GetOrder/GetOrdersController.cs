using OrderService.Application.Orders.GetOrder;
using BuildingBlocks.Web;
using Microsoft.AspNetCore.Mvc;

namespace OrderService.Api.Order.GetOrder
{
    public class GetOrdersController : UserController
    {
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            return HandleResult(await Mediator.Send(new GetOrderByIdQuery.Query(id)));
        }
    }
}