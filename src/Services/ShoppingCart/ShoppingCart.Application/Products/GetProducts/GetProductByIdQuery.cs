using BuildingBlocks.Core;
using Catalog.Domain.Products;
using MediatR;

namespace ShoppingCart.Application.Products.GetProducts;

public sealed class GetProductByIdQuery
{
    public class Query : IRequest<Result<ProductDto>>
    {
        public Query(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }

    public class Handler : IRequestHandler<Query, Result<ProductDto>>
    {
        private readonly IProductRepository _productRepository;

        public Handler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result<ProductDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await GetProductById(request.Id)
                .ConfigureAwait(false);

            return result != null ? Result<ProductDto>.Success(result) : Result<ProductDto>.Failure("Not found");
        }

        private async Task<ProductDto?> GetProductById(Guid id)
        {
            Product? product = await _productRepository
                .GetProductById(id)
                .ConfigureAwait(false);

            return product != null ? new ProductDto(product) : null;
        }
    }
}