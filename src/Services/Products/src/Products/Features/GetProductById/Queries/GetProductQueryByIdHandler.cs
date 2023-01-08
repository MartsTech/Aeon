using Ardalis.GuardClauses;
using BuildingBlocks.Core.CQRS;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Products.Data;
using Products.Products.Dtos;
using Products.Products.Exceptions;

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

        var product =
            await _productDbContext.Products.SingleOrDefaultAsync(x => x.Id == query.Id, cancellationToken);

        if (product is null)
            throw new ProductNotFoundException();

        return _mapper.Map<ProductResponseDto>(product);
    }
}