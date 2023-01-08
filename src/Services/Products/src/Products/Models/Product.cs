using BuildingBlocks.Core.Model;
using Products.Products.Features.CreateProduct.Events.Domain;

namespace Products.Products.Models;

public record Product: Aggregate<long>
{
    public string Name { get; private set; }
    
    public Enums.ProductType ProductType { get; private set; }
    
    public static Product Create(long id, string name, Enums.ProductType productType, bool isDeleted = false)
    {
        var product = new Product()
        {
            Id = id,
            Name = name,
            ProductType = productType,
            IsDeleted = isDeleted,
        };

        var @event = new ProductCreatedDomainEvent(product.Id, product.Name, product.ProductType, product.IsDeleted);

        product.AddDomainEvent(@event);

        return product;
    }
}