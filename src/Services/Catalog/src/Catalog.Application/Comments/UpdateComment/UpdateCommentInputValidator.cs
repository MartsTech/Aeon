using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Catalog.Application.Comments.UpdateComment
{
    internal class UpdateCommentInputValidator : AbstractValidator<UpdateCommentInput>
    {
        public UpdateCommentInputValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
            RuleFor(c => c.Content).NotEmpty().MaximumLength(255);
        }
    }
}
