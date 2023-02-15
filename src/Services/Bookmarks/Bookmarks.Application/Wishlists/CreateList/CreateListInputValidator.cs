using FluentValidation;

namespace Bookmarks.Application.Wishlists.CreateList
{
    internal class CreateListInputValidator : AbstractValidator<CreateListInput>
    {
        public CreateListInputValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
}
