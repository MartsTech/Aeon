using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Comments.AddUpvote
{
    public class AddUpvoteInput
    {
        [Required]
        public Guid CommentId { get; set; }
    }
}
