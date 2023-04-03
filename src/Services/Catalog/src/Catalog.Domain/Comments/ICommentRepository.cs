namespace Catalog.Domain.Comments;

public interface ICommentRepository
{
    Task<List<Comment>> GetCommentsByProduct(Guid productId);
    Task<List<Comment>> GetCommentsByUser(Guid userId);
    Task<Comment?> GetCommentById(Guid id);
    Task AddComment(Comment comment);
    Task<bool> UpdateComment(Guid id, string newComment);
    Task<bool> DeleteComment(Guid id);
}