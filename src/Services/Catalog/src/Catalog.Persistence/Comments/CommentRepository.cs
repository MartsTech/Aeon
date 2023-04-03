using Catalog.Domain.Comments;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Persistence.Comments
{
    public class CommentRepository : ICommentRepository
    {
        private readonly CatalogDbContext _context;

        public CommentRepository(CatalogDbContext context)
        {
            _context = context;
        }

        public async Task<List<Comment>> GetCommentsByProduct(Guid productId)
        {
            return await _context.Comments.Where(c => c.ProductId == productId).Include(c => c.Upvotes).ToListAsync().ConfigureAwait(false);
        }

        public async Task<List<Comment>> GetCommentsByUser(Guid userId)
        {
            return await _context.Comments.Where(c => c.UserId == userId).Include(c => c.Upvotes).ToListAsync().ConfigureAwait(false);
        }

        public async Task<Comment?> GetCommentById(Guid id)
        {
            return await _context.Comments.Include(c => c.Upvotes).FirstOrDefaultAsync(c => c.Id == id).ConfigureAwait(false);
        }

        public async Task AddComment(Comment comment)
        {
            await _context.Comments.AddAsync(comment).ConfigureAwait(false);
        }

        public async Task<bool> UpdateComment(Guid id, string comment)
        {
            Comment? dbComment = await GetCommentById(id).ConfigureAwait(false);
            if (dbComment == null)
            {
                return false;
            }

            dbComment.Content = comment;

            _context.Comments.Update(dbComment);
            return true;
        }

        public async Task<bool> DeleteComment(Guid id)
        {
            Comment? comment = await GetCommentById(id).ConfigureAwait(false);
            if (comment == null)
            {
                return false;
            }

            _context.Comments.Remove(comment);
            //await _context.SaveChangesAsync().ConfigureAwait(false);

            return true;
        }
    }
}
