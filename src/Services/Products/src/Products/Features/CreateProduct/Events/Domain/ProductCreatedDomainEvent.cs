using BuildingBlocks.Core.Event;

namespace Products.Products.Features.CreateProduct.Events.Domain;

public record ProductCreatedDomainEvent(long Id, string Name, Enums.ProductType ProductType, bool IsDeleted) : IDomainEvent;