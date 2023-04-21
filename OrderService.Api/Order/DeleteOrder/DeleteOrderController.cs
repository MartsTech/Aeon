using OrderService.Application.Orders.DeleteOrder;
using BuildingBlocks.Core;
using BuildingBlocks.MassTransit.Contracts;
using BuildingBlocks.Web;
using Microsoft.AspNetCore.Mvc;

namespace OrderService.Api.Order.DeleteOrder
{
    public class DeleteOrderController : UserController
    {
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            Result<string> result = await Mediator.Send(new DeleteOrderCommand.Command(id));

            if (result.IsSuccess)
            {
                var @event = new OrderDeleted(id);
                HandlePublish(@event);
            }

            return HandleResult(result);
        }
    }
}
