using System.ComponentModel.DataAnnotations;

namespace Bookmarks.Application.Wishlists.CreateList
{
    public class CreateListInput
    {
        [Required] public Guid UserId { get; set; }
    }
}