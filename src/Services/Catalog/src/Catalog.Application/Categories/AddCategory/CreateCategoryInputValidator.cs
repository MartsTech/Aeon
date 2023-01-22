using FluentValidation;

namespace Catalog.Application.Categories.AddCategory
{
    internal class CreateCategoryInputValidator : AbstractValidator<CreateCategoryInput>
    {
        public CreateCategoryInputValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(90);
        }
    }
}
