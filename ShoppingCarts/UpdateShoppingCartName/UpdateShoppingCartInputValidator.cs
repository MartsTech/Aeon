using FluentValidation;

namespace Catalog.Application.Categories.UpdateCategoryName
{
    internal class UpdateShoppingCartInputValidator : AbstractValidator<UpdateShoppingCartInput>
    {
        public UpdateShoppingCartInputValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.NewName).NotEmpty().MaximumLength(90);
        }
    }
}
