using System.ComponentModel.DataAnnotations.Schema;
using Bookmarks.Domain.Wishlists;

namespace Bookmarks.Domain.Bookmarks
{
    public class Bookmark : IBookmark
    {
        public Bookmark(Guid id, Guid productId, int productQuantity, DateOnly dateAdded, Guid listId)
        {
            Id = id;
            ProductId = productId;
            ProductQuantity = productQuantity;
            DateAdded = dateAdded;
            ListId = listId;
        }

        public Guid Id { get; }
        public Guid ProductId { get; }
        public int ProductQuantity { get; set; }
        public DateOnly DateAdded { get; }
        [ForeignKey(nameof(List))]
        public Guid ListId { get; }
        public Wishlist List { get; }
    }
}
