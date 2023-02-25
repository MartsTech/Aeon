using FluentValidation;

namespace OrderService.Application.Orders.AddOrder
{
    internal class AddOrderInputValidator : AbstractValidator<AddOrderInput>
    {
        public AddOrderInputValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty();
            RuleFor(x => x.ListId).NotEmpty();
            RuleFor(x => x.Quantity).NotEmpty().GreaterThanOrEqualTo(1);
        }
    }
}