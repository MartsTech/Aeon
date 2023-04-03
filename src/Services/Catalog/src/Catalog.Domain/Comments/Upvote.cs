namespace Catalog.Domain.Comments;

public class Upvote : IUpvote
{
    public Upvote(Guid id, Guid userId, Guid commentId)
    {
        Id = id;
        UserId = userId;
        CommentId = commentId;
    }

    public Guid Id { get; }
    public Guid UserId { get; }
    public Guid CommentId { get; }
    public Comment Comment { get; set; }
}