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
        endpoints.MapGet($"{EndpointConfig.BaseApiPath}/passenger/{{id}}", GetById)
            .RequireAuthorization()
            .WithTags("Passenger")
            .WithName("GetPassengerById")
            .WithMetadata(new SwaggerOperationAttribute("Get Passenger By Id", "Get Passenger By Id"))
            .WithApiVersionSet(endpoints.NewApiVersionSet("Passenger").Build())
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