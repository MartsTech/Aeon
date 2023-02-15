namespace Bookmarks.Domain.Bookmarks
{
    public interface IBookmarkRepository
    {
        Task<bool> AddBookmark(Bookmark bookmark, Guid listId);
        Task<Bookmark?> GetBookmarkById(Guid id);
        Task<bool> UpdateBookmark(Guid id, int newQuantity);
        Task<bool> DeleteBookmark(Guid id);
    }
}