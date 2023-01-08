using BuildingBlocks.Web;
using MediatR;
using Products.Products.Dtos;
using Products.Products.Features.GetProductById.Queries;
using Swashbuckle.AspNetCore.Annotations;

namespace Products.Products.Features.GetProductById.Endpoints;

public class GetPassengerByIdEndpoint : IMinimalEndpoint
{
    public IEndpointRouteBuilder MapEndpoint(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet($"{EndpointConfig.BaseApiPath}/products/{{id}}", GetById)
            .RequireAuthorization()
            .WithTags("Product")
            .WithName("GetProductById")
            .WithMetadata(new SwaggerOperationAttribute("Get Product By Id", "Get Product By Id"))
            .WithApiVersionSet(endpoints.NewApiVersionSet("Product").Build())
            .Produces<ProductResponseDto>()
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .HasApiVersion(1.0);

        return endpoints;
    }

    private async Task<IResult> GetById(long id, IMediator mediator, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetProductQueryById(id), cancellationToken);

        return Results.Ok(result);
    }
}