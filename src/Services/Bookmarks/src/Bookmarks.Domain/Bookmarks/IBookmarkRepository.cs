namespace Bookmarks.Domain.Bookmarks
{
    public interface IBookmarkRepository
    {
        Task<bool> AddBookmark(Bookmark bookmark);
        Task<Bookmark?> GetBookmarkById(Guid id, Guid userId);
        Task<bool> UpdateBookmark(Guid id, int newQuantity, Guid userId);
        Task<bool> DeleteBookmark(Guid id, Guid userId);
    }
}