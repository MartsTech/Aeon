using BuildingBlocks.Core;
using BuildingBlocks.MassTransit.Contracts;
using BuildingBlocks.Web;
using Catalog.Application.Products;
using Catalog.Application.Products.UpdateProduct;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Products.UpdateProduct
{
    public class UpdateProductController : UserController
    {
        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromForm] UpdateProductInput input)
        {
            Result<ProductDto> result = await Mediator.Send(new UpdateProductCommand.Command(input));

            if (result.Value != null)
            {
                var @event = new ProductUpdated(result.Value.Id);
                HandlePublish(@event);
            }

            return HandleResult(result);
        }
    }
}
