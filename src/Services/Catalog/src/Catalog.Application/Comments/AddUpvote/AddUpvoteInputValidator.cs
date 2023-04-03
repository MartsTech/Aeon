using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Catalog.Application.Comments.AddUpvote
{
    internal class AddUpvoteInputValidator : AbstractValidator<AddUpvoteInput>
    {
        public AddUpvoteInputValidator()
        {
            RuleFor(u => u.CommentId).NotEmpty();
        }
    }
}
