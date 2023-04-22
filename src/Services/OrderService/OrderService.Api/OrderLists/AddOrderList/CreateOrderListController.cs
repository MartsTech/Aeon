using OrderService.Application.OrderLists;
using OrderService.Application.OrderLists.CreateList;
using BuildingBlocks.Core;
using BuildingBlocks.MassTransit.Contracts;
using BuildingBlocks.Web;
using Microsoft.AspNetCore.Mvc;

namespace OrderService.Api.OrderLists.CreateOrderList
{
    public class CreateOrderListController : UserController
    {
        [HttpPost]
        public async Task<IActionResult> AddOrderList([FromForm] CreateOrderListInput input)
        {
            Result<OrderListDto> result = await Mediator.Send(new CreateOrderListCommand.Command(input));

            if (result.Value != null)
            {
                var @event = new OrderListCreated(result.Value.Id);
                HandlePublish(@event);
            }

            return HandleResult(result);
        }
    }
}
