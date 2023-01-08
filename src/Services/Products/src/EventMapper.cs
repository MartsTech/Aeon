using BuildingBlocks.Contracts.EventBus.Messages;
using BuildingBlocks.Core;
using BuildingBlocks.Core.Event;
using Products.Products.Features.CreateProduct.Commands.Reads;
using Products.Products.Features.CreateProduct.Events.Domain;

namespace Products;

public sealed class EventMapper: IEventMapper
{
    public IIntegrationEvent? MapToIntegrationEvent(IDomainEvent @event)
    {
        return @event switch
        {
            ProductCreatedDomainEvent e => new ProductCreated(e.Id),
            _ => null
        };
    }

    public IInternalCommand? MapToInternalCommand(IDomainEvent @event)
    {
        return @event switch
        {
            ProductCreatedDomainEvent e => new CreateProductMongoCommand(e.Id, e.Name, e.ProductType, e.IsDeleted),
            _ => null
        };
    }
}