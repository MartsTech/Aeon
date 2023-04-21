using BuildingBlocks.Core;
using BuildingBlocks.MassTransit.Contracts;
using BuildingBlocks.Web;
using ShoppingCart.Application.ShoppingCarts;
using CatalShoppingCart.Application.ShoppingCarts.CreateShoppingCart;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingCart.Api.ShoppingCarts.CreateShoppingCart
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

