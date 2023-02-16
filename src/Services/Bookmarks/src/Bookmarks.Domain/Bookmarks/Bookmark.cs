using Bookmarks.Domain.Wishlists;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookmarks.Domain.Bookmarks
{
    public class Bookmark : IBookmark
    {
        public Bookmark(Guid id, Guid productId, int productQuantity, DateOnly dateAdded,Guid userId, Guid listId)
        {
            Id = id;
            ProductId = productId;
            ProductQuantity = productQuantity;
            DateAdded = dateAdded;
            ListId = listId;
            UserId = userId;
        }

        public Guid Id { get; }
        public Guid ProductId { get; }
        public int ProductQuantity { get; set; }
        public DateOnly DateAdded { get; }
        public Guid UserId { get; }
        public Guid ListId { get; }
        public Wishlist List { get; }
    }
}