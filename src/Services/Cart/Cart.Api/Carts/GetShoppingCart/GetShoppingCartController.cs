using BuildingBlocks.Web;
using Cart.Application.Carts.GetShoppingCart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cart.Api.ShoppingCarts.GetShoppingCart
{
    [AllowAnonymous]
    public class GetShoppingCartController : UserController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllShoppingCarts()
        {
            return HandleResult(await Mediator.Send(new GetAllShoppingCartsQuery.Query(false)));
        }

        [HttpGet("{includeProducts:bool}")]
        public async Task<IActionResult> GetAllShoppingCarts(bool includeProducts)
        {
            return HandleResult(await Mediator.Send(new GetAllShoppingCartsQuery.Query(includeProducts)));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetShoppingCartById(Guid id)
        {
            return HandleResult(await Mediator.Send(new GetShoppingCartByIdQuery.Query(id)));
        }

   
    }
}
