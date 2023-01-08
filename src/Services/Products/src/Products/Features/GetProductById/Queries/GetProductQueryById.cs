using BuildingBlocks.Core.CQRS;
using Products.Products.Dtos;

namespace Products.Products.Features.GetProductById.Queries;

public record GetProductQueryById(long Id) : IQuery<ProductResponseDto>;