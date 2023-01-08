using BuildingBlocks.Core.Model;

namespace Products.Products.Models;

public record Product: Aggregate<long>
{
    public string Name { get; private set; }
    
    public Enums.ProductType ProductType { get; private set; }
}