using FluentValidation;

namespace Bookmarks.Application.Bookmarks.UpdateBookmark
{
    internal class UpdateBookmarkInputValidator : AbstractValidator<UpdateBookmarkInput>
    {
        public UpdateBookmarkInputValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Quantity).NotEmpty().GreaterThanOrEqualTo(1);
        }
    }
}