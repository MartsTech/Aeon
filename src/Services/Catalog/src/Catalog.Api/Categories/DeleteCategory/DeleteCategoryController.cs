using BuildingBlocks.Core;
using BuildingBlocks.MassTransit.Contracts;
using BuildingBlocks.Web;
using Catalog.Application.Categories.DeleteCategory;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Categories.DeleteCategory
{
    public class DeleteCategoryController : UserController
    {
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            Result<string> result = await Mediator.Send(new DeleteCategoryCommand.Command(id));

            if (result.IsSuccess)
            {
                var @event = new CategoryDeleted(id);
                HandlePublish(@event);
            }

            return HandleResult(result);
        }
    }
}
