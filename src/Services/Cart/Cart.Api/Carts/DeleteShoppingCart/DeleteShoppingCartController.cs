using BuildingBlocks.Core;
using BuildingBlocks.MassTransit.Contracts;
using BuildingBlocks.Web;
using Microsoft.AspNetCore.Mvc;
using Cart.Application.Carts.DeleteShoppingCart;

namespace Cart.Api.ShoppingCarts.DeleteShoppingCart
{
    public class DeleteShoppingCartController : AdminController
    {
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteShoppingCart(Guid id)
        {
            Result<string> result = await Mediator.Send(new DeleteShoppingCartCommand.Command(id));

            if (result.IsSuccess)
            {
                var @event = new ShoppingCartDeleted(id);
                HandlePublish(@event);
            }

            return HandleResult(result);
        }
    }
}
