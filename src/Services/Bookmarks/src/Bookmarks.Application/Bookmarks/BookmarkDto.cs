using Bookmarks.Domain.Bookmarks;

namespace Bookmarks.Application.Bookmarks
{
    public class BookmarkDto : IBookmark
    {
        public BookmarkDto(IBookmark bookmark)
        {
            Id = bookmark.Id;
            ProductId = bookmark.ProductId;
            ProductQuantity = bookmark.ProductQuantity;
            DateAdded = bookmark.DateAdded;
            ListId = bookmark.ListId;
            UserId = bookmark.UserId;
        }

        public Guid Id { get; }
        public Guid ProductId { get; }
        public int ProductQuantity { get; }
        public DateOnly DateAdded { get; }
        public Guid ListId { get; }
        
        public Guid UserId { get; }
    }
}