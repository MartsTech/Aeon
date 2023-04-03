namespace Catalog.Domain.Comments;

public interface IUpvote
{
    public Guid Id { get; }
    public Guid UserId { get; }
    public Guid CommentId { get; }
}