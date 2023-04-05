using Catalog.Domain.Comments;

namespace Catalog.Application.Comments;

public sealed record UpvoteDto : IUpvote
{
    public UpvoteDto(IUpvote upvote)
    {
        Id = upvote.Id;
        UserId = upvote.UserId;
        CommentId = upvote.CommentId;
    }

    public Guid Id { get; }
    public Guid UserId { get; }
    public Guid CommentId { get; }
}