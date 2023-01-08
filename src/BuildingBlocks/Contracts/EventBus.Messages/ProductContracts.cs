using BuildingBlocks.Core.Event;

namespace BuildingBlocks.Contracts.EventBus.Messages;

public record ProductCreated(long Id) : IIntegrationEvent;