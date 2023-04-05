using System.ComponentModel.DataAnnotations;

namespace Catalog.Application.Comments.AddUpvote;

public class AddUpvoteInput
{
    [Required] public Guid CommentId { get; set; }
}