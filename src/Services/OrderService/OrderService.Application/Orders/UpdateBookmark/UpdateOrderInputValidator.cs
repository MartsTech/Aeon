using FluentValidation;

namespace OrderService.Application.Orders.UpdateOrders
{
    internal class UpdateOrderInputValidator : AbstractValidator<UpdateOrderInput>
    {
        public UpdateOrderInputValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Quantity).NotEmpty().GreaterThanOrEqualTo(1);
        }
    }
}