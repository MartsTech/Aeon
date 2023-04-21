using OrderService.Application.OrderLists;
using OrderService.Application.OrderLists.AddOrderList;
using BuildingBlocks.Core;
using BuildingBlocks.MassTransit.Contracts;
using BuildingBlocks.Web;
using Microsoft.AspNetCore.Mvc;

namespace OrderService.Api.OrderLists.AddOrderList
{
    public class AddOrderListController : UserController
    {
        [HttpPost]
        public async Task<IActionResult> AddOrderList([FromForm] AddOrderListInput input)
        {
            Result<WishlistDto> result = await Mediator.Send(new AddOrderListCommand.Command(input));

            if (result.Value != null)
            {
                var @event = new OrderListCreated(result.Value.Id);
                HandlePublish(@event);
            }

            return HandleResult(result);
        }
    }
}
