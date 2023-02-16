namespace Bookmarks.Domain.Wishlists
{
    public interface IWishlistRepository
    {
        Task<List<Wishlist>> GetAllLists(Guid userId, bool includeBookmarks);
        Task<Wishlist?> GetListById(Guid userId, Guid id);
        Task CreateNewList(Wishlist wishlist);
        Task<bool> DeleteList(Guid id);
    }
}