using BuildingBlocks.Core;
using BuildingBlocks.MassTransit.Contracts;
using BuildingBlocks.Web;
using Cart.Domain.Carts;
using Cart.Application.Carts.CreateShoppingCart;
using Cart.Application.Carts;
using Microsoft.AspNetCore.Mvc;

namespace Cart.Api.Carts.CreateShoppingCart
{
    public class AddShoppingCartController : AdminController
    {
        [HttpPost]
        public async Task<IActionResult> AddShoppingCart([FromForm] CreateShoppingCartInput input)
        {
            Result<ShoppingCartDto> result = await Mediator.Send(new CreateShoppingCartCommand.Command(input));

            if (result.Value != null)
            {
                var @event = new ShoppingCartCreated(result.Value.Id);
                HandlePublish(@event);
            }

            return HandleResult(result);
        }
    }
}

