using Ardalis.GuardClauses;
using BuildingBlocks.Core.CQRS;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Products.Data;
using Products.Products.Dtos;
using Products.Products.Features.GetProductById.Exceptions;

namespace Products.Products.Features.GetProductById.Queries;

public class GetProductQueryByIdHandler : IQueryHandler<GetProductQueryById, ProductResponseDto>
{
    private readonly ProductDbContext _productDbContext;
    private readonly IMapper _mapper;

    public GetProductQueryByIdHandler(IMapper mapper, ProductDbContext productDbContext)
    {
        _mapper = mapper;
        _productDbContext = productDbContext;
    }

    public async Task<ProductResponseDto> Handle(GetProductQueryById query, CancellationToken cancellationToken)
    {
        Guard.Against.Null(query, nameof(query));

        var passenger =
            await _productDbContext.Passengers.SingleOrDefaultAsync(x => x.Id == query.Id, cancellationToken);

        if (passenger is null)
            throw new ProductNotFoundException();

        return _mapper.Map<ProductResponseDto>(passenger!);
    }
}