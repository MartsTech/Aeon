using System.ComponentModel.DataAnnotations;

namespace Bookmarks.Application.Bookmarks.AddBookmark
{
    public class AddBookmarkInput
    {
        [Required] public Guid ProductId { get; set; }
        [Required] public int Quantity { get; set; }
        [Required] public Guid ListId { get; set; }
    }
}