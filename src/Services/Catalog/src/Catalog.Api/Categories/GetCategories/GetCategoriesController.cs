using BuildingBlocks.Web;
using Catalog.Application.Categories.GetCategories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Categories.GetCategories
{
    [AllowAnonymous]
    public class GetCategoriesController : UserController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            return HandleResult(await Mediator.Send(new GetAllCategoriesQuery.Query(false)));
        }

        [HttpGet("{includeProducts:bool}")]
        public async Task<IActionResult> GetAllCategories(bool includeProducts)
        {
            return HandleResult(await Mediator.Send(new GetAllCategoriesQuery.Query(includeProducts)));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            return HandleResult(await Mediator.Send(new GetCategoryByIdQuery.Query(id)));
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetCategoryByName(string name)
        {
            return HandleResult(await Mediator.Send(new GetCategoryByNameQuery.Query(name)));
        }
    }
}