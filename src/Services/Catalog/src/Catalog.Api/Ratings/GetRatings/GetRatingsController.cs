using BuildingBlocks.Web;
using Catalog.Application.Ratings.GetRatings;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Ratings.GetRatings;

public class GetRatingsController : UserController
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetRatingById(Guid id)
    {
        return HandleResult(await Mediator.Send(new GetRatingByIdQuery.Query(id)));
    }

    [HttpGet("product/{productId:guid}")]
    public async Task<IActionResult> GetRatingsByProductId(Guid productId)
    {
        return HandleResult(await Mediator.Send(new GetRatingsOfProductQuery.Query(productId)));
    }

    [HttpGet("user/{userId:guid}")]
    public async Task<IActionResult> GetRatingsByUserId(Guid userId)
    {
        return HandleResult(await Mediator.Send(new GetRatingsByUserQuery.Query(userId)));
    }
}