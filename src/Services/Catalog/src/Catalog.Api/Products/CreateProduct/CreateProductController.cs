using BuildingBlocks.Core;
using BuildingBlocks.MassTransit.Contracts;
using BuildingBlocks.Web;
using Catalog.Application.Products;
using Catalog.Application.Products.CreateProduct;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Products.CreateProduct
{
    public class CreateProductController : UserController
    {
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromForm] CreateProductInput input)
        {
            Result<ProductDto> result = await Mediator.Send(new CreateProductCommand.Command(input));

            if (result.Value != null)
            {
                var @event = new ProductCreated(result.Value.Id);
                HandlePublish(@event);
            }

            return HandleResult(result);
        }
    }
}
