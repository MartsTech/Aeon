using OrderService.Application.OrderLists.DeleteOrderList;
using BuildingBlocks.Core;
using BuildingBlocks.MassTransit.Contracts;
using BuildingBlocks.Web;
using Microsoft.AspNetCore.Mvc;

namespace OrderService.Api.OrderLists.DeleteOrderList
{
    public class DeleteOrderListController : UserController
    {
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteOrderList(Guid id)
        {
            Result<string> result = await Mediator.Send(new DeleteOrderListCommand.Command(id));

            if (result.IsSuccess)
            {
                var @event = new OrderListDeleted(id);
                HandlePublish(@event);
            }

            return HandleResult(result);
        }
    }
}
