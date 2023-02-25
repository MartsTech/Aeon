namespace Bookmarks.Domain.Wishlists
{
    public interface IShoppingCart
    {
        public Guid Id { get; }
        public Guid UserId { get; }
        public DateOnly DateCreated { get; }
    }
}