namespace BuildingBlocks.MassTransit.Contracts;

public record ProductCreated(Guid Id);
public record ProductUpdated(Guid Id);
public record ProductDeleted(Guid Id);
public record CategoryCreated(Guid Id);
public record CategoryUpdated(Guid Id);
public record CategoryDeleted(Guid Id);