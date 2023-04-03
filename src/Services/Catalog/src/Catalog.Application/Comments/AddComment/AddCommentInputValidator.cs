using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Catalog.Application.Comments.AddComment
{
    internal class AddCommentInputValidator : AbstractValidator<AddCommentInput>
    {
        public AddCommentInputValidator()
        {
            RuleFor(c => c.ProductId).NotEmpty();
            RuleFor(c => c.Content).NotEmpty().MaximumLength(255);
        }
    }
}
