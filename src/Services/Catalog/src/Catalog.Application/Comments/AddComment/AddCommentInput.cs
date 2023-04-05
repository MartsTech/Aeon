using System.ComponentModel.DataAnnotations;

namespace Catalog.Application.Comments.AddComment;

public class AddCommentInput
{
    [Required] public Guid ProductId { get; set; }
    [Required] [MaxLength(255)] public string Content { get; set; }
}