using FluentValidation;

namespace Catalog.Application.Categories.AddCategory
{
    internal class CreateShoppingCartInputValidator : AbstractValidator<CreateShoppinCartInput>
    {
        public CreateShoppingCartInputValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(90);
        }
    }
}
