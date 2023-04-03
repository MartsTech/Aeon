using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Comments.AddComment
{
    public class AddCommentInput
    {
        [Required] 
        public Guid ProductId { get; set; }
        [Required]
        [MaxLength(255)]
        public string Content { get; set; }
    }
}
