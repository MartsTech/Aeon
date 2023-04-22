using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Cart.Application.Carts.CreateShoppingCart;

namespace Cart.Application.Carts.CreateShoppingCarts
{
    internal class CreateShoppingCartInputValidator : AbstractValidator<CreateShoppingCartInput>
    {
        public CreateShoppingCartInputValidator()
        {
        }
    }
}

