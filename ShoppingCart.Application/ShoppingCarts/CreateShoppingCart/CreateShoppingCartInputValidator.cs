using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ShoppingCart.Application.ShoppingCarts.CreateShoppingCart;

namespace ShoppingCart.Application.ShoppingCarts.CreateShoppingCarts
{
    internal class CreateShoppingCartInputValidator : AbstractValidator<CreateShoppingCartInput>
    {
        public CreateShoppingCartInputValidator()
        {
        }
    }
}

