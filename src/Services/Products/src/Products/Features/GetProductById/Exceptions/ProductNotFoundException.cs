using BuildingBlocks.Exception;

namespace Products.Products.Features.GetProductById.Exceptions;

public class ProductNotFoundException:  NotFoundException
{
    public ProductNotFoundException(string code = default) : base("Product not found!")
    {
    }
}