using FluentValidation;

namespace OrderService.Application.Orders.AddOrder
{
    internal class AddOrderServiceInputValidator : AbstractValidator<AddOrderServiceInput>
    {
        public AddOrderServiceInputValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty();
            RuleFor(x => x.Quantity).NotEmpty().GreaterThanOrEqualTo(1);
        }
    }
}
