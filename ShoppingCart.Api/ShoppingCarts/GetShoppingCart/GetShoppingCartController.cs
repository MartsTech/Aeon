using BuildingBlocks.Web;
using ShoppingCart.Application.ShoppingCarts.GetShoppingCart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingCart.Api.ShoppingCarts.GetShoppingCart
{
    [AllowAnonymous]
    public class GetShoppingCartController : UserController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            return HandleResult(await Mediator.Send(new GetAllShoppingCartsQuery.Query(false)));
        }

        [HttpGet("{includeProducts:bool}")]
        public async Task<IActionResult> GetAllCategories(bool includeProducts)
        {
            return HandleResult(await Mediator.Send(new GetAllShoppingCartsQuery.Query(includeProducts)));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            return HandleResult(await Mediator.Send(new GetCategoryByIdQuery.Query(id)));
        }

   
    }
}
