using FluentValidation;

namespace Catalog.Application.Categories.UpdateCategoryName
{
    internal class UpdateCategoryInputValidator : AbstractValidator<UpdateCategoryInput>
    {
        public UpdateCategoryInputValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.NewName).NotEmpty().MaximumLength(90);
        }
    }
}
