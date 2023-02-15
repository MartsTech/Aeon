using FluentValidation;

namespace Bookmarks.Application.Bookmarks.AddBookmark
{
    internal class AddBoookmarkInputValidator : AbstractValidator<AddBookmarkInput>
    {
        public AddBoookmarkInputValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty();
            RuleFor(x => x.ListId).NotEmpty();
            RuleFor(x => x.Quantity).NotEmpty().GreaterThanOrEqualTo(1);
        }
    }
}