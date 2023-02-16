using BuildingBlocks.Core;
using BuildingBlocks.MassTransit.Contracts;
using BuildingBlocks.Web;
using Catalog.Application.Categories;
using Catalog.Application.Categories.UpdateCategoryName;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Categories.UpdateCategoryName
{
    public class UpdateCategoryController : AdminController
    {
        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromForm] UpdateCategoryInput input)
        {
            Result<CategoryDto> result = await Mediator.Send(new UpdateCategoryCommand.Command(input));

            if (result.Value != null)
            {
                var @event = new CategoryUpdated(result.Value.Id);
                HandlePublish(@event);
            }

            return HandleResult(result);
        }
    }
}
