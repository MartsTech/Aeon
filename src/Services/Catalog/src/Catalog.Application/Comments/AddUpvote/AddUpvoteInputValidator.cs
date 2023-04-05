using FluentValidation;

namespace Catalog.Application.Comments.AddUpvote;

internal class AddUpvoteInputValidator : AbstractValidator<AddUpvoteInput>
{
    public AddUpvoteInputValidator()
    {
        RuleFor(u => u.CommentId).NotEmpty();
    }
}