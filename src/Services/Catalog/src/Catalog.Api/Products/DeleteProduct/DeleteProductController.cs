using BuildingBlocks.Core;
using BuildingBlocks.MassTransit.Contracts;
using BuildingBlocks.Web;
using Catalog.Application.Products;
using Catalog.Application.Products.DeleteProduct;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Products.DeleteProduct
{
    public class DeleteProductController : AdminController
    {
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            Result<string> result = await Mediator.Send(new DeleteProductCommand.Command(id));

            if (result.IsSuccess)
            {
                var @event = new ProductDeleted(id);
                HandlePublish(@event);
            }

            return HandleResult(result);
        }
    }
}
