namespace Catalog.Domain.Comments
{
    public interface IUpvoteRepository
    {
        Task<List<Upvote>> GetUpvotesOfComment(Guid commentId);
        Task<Upvote?> GetUpvoteById(Guid id);
        Task<bool> AddUpvote(Upvote upvote);
        Task<bool> DeleteUpvote(Guid id);
    }
}
