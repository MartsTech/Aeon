using BuildingBlocks.Core;
using ShoppingCart.Domain.Products;
using MediatR;

namespace ShoppingCart.Application.Products.GetProducts;

public sealed class GetAllProductsQuery
{
    public class Query : IRequest<Result<IList<ProductDto>>>
    {
    }

    public class Handler : IRequestHandler<Query, Result<IList<ProductDto>>>
    {
        private readonly IProductRepository _productRepository;

        public Handler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result<IList<ProductDto>>> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await GetAllProducts()
                .ConfigureAwait(false);
            
            return Result<IList<ProductDto>>.Success(result);
        }
        
        private async Task<IList<ProductDto>> GetAllProducts()
        {
            List<Product> products = await _productRepository
                .GetAllProducts()
                .ConfigureAwait(false);
            
            return new List<ProductDto>(products.Select(product => new ProductDto(product)));
        }
    }
}