using System.ComponentModel.DataAnnotations;

namespace Bookmarks.Application.Bookmarks.UpdateBookmark
{
    public class UpdateBookmarkInput
    {
        [Required] public Guid Id { get; set; }
        [Required] public int Quantity { get; set; }
    }
}