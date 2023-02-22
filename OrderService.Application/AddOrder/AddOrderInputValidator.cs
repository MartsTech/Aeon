using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;


namespace OrderService.Application.AddOrder
{
    nternal class AddOrderInputValidator : AbstractValidator<AddOrderInput>
    {
        public AddOrderInputValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty();
            RuleFor(x => x.ListId).NotEmpty();
            RuleFor(x => x.Quantity).NotEmpty().GreaterThanOrEqualTo(1);
        }
    }
}
