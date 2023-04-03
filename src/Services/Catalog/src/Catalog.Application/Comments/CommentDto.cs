using Catalog.Domain.Comments;

namespace Catalog.Application.Comments;

public sealed record CommentDto
{
    public CommentDto(IComment comment)
    {
        Id = comment.Id;
        UserId = comment.UserId;
        ProductId = comment.ProductId;
        Content = comment.Content;
        UpvoteCount = comment.Upvotes.Count;
    }

    public Guid Id { get; }
    public Guid UserId { get; }
    public Guid ProductId { get; }
    public string Content { get; }
    public int UpvoteCount { get; }
}