using OrderService.Application.Orders;
using OrderService.Application.Orders.AddOrder;
using BuildingBlocks.Core;
using BuildingBlocks.MassTransit.Contracts;
using BuildingBlocks.Web;
using Microsoft.AspNetCore.Mvc;

namespace OrderService.Api.Order.AddOrder
{
    public class AddOrderController : UserController
    {
        [HttpPost]
        public async Task<IActionResult> AddOrder([FromForm] AddOrderInput input)
        {
            Result<OrderDto> result = await Mediator.Send(new AddOrderCommand.Command(input));

            if (result.Value != null)
            {
                var @event = new OrderCreated(result.Value.Id);
                HandlePublish(@event);
            }

            return HandleResult(result);
        }
    }
}
