using System.ComponentModel.DataAnnotations;

namespace Catalog.Application.Comments.UpdateComment;

public class UpdateCommentInput
{
    [Required] public Guid Id { get; set; }
    [Required] [MaxLength(255)] public string Content { get; set; }
}