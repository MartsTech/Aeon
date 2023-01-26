using BuildingBlocks.Web;
using Catalog.Application.Products.GetProducts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Products.GetProducts
{
    [AllowAnonymous]
    public class GetProductsController : UserController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            return HandleResult(await Mediator.Send(new GetAllProductsQuery.Query()));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            return HandleResult(await Mediator.Send(new GetProductByIdQuery.Query(id)));
        }
    }
}