using BuildingBlocks.Exception;

namespace Products.Products.Exceptions;

public class ProductNotFoundException:  NotFoundException
{
    public ProductNotFoundException() : base("Product not found!")
    {
    }
}