namespace BuildingBlocks.MassTransit.Contracts;

public record ProductCreated(Guid Id);
public record ProductUpdated(Guid Id);
public record ProductDeleted(Guid Id);
public record CategoryCreated(Guid Id);
public record CategoryUpdated(Guid Id);
public record CategoryDeleted(Guid Id);
public record BookmarkCreated(Guid Id);
public record BookmarkUpdated(Guid Id);
public record BookmarkDeleted(Guid Id);
public record WishlistCreated(Guid Id);
public record WishlistDeleted(Guid Id);
public record CommentCreated(Guid Id);
public record CommentUpdated(Guid Id);
public record CommentDeleted(Guid Id);
public record UpvoteCreated(Guid Id);
public record UpvoteDeleted(Guid Id);