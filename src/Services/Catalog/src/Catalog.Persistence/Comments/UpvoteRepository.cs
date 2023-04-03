using Catalog.Domain.Comments;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Persistence.Comments
{
    public class UpvoteRepository : IUpvoteRepository
    {
        private readonly CatalogDbContext _context;

        public UpvoteRepository(CatalogDbContext context)
        {
            _context = context;
        }

        public async Task<List<Upvote>> GetUpvotesOfComment(Guid commentId)
        {
            return await _context.Upvotes.Where(u => u.CommentId == commentId).ToListAsync().ConfigureAwait(false);
        }

        public async Task<Upvote?> GetUpvoteById(Guid id)
        {
            return await _context.Upvotes.FirstOrDefaultAsync(u => u.Id == id).ConfigureAwait(false);
        }

        public async Task<bool> AddUpvote(Upvote upvote)
        {
            if (_context.Upvotes.Any(u => u.UserId == upvote.UserId && u.CommentId == upvote.CommentId))
            {
                return false;
            }

            await _context.Upvotes.AddAsync(upvote).ConfigureAwait(false);
            return true;
        }

        public async Task<bool> DeleteUpvote(Guid id)
        {
            Upvote? upvote = await GetUpvoteById(id).ConfigureAwait(false);
            if (upvote == null)
            {
                return false;
            }

            _context.Upvotes.Remove(upvote);
            //await _context.SaveChangesAsync().ConfigureAwait(false);

            return true;
        }
    }
}
