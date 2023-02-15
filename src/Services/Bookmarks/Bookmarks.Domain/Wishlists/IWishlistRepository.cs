namespace Bookmarks.Domain.Wishlists
{
    public interface IWishlistRepository
    {
        Task<List<Wishlist>> GetAllLists(bool includeBookmarks);
        Task<Wishlist?> GetListById(Guid id);
        Task CreateNewList(Wishlist wishlist);
        Task<bool> DeleteList(Guid id);
    }
}
