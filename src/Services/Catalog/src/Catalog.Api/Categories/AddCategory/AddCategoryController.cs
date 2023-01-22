using BuildingBlocks.Core;
using BuildingBlocks.MassTransit.Contracts;
using BuildingBlocks.Web;
using Catalog.Application.Categories;
using Catalog.Application.Categories.AddCategory;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Categories.AddCategory
{
    public class AddCategoryController : UserController
    {
        [HttpPost]
        public async Task<IActionResult> AddCategory([FromForm] CreateCategoryInput input)
        {
            Result<CategoryDto> result = await Mediator.Send(new CreateCategoryCommand.Command(input));

            if (result.Value != null)
            {
                var @event = new CategoryCreated(result.Value.Id);
                HandlePublish(@event);
            }

            return HandleResult(result);
        }
    }
}
