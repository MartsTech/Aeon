using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Domain.ShoppingCarts;

namespace ShoppingCart.Domain
{
    public interface IEntityFactory
    {
        ShoppingCart NewShoppingCart(Guid id);

    }
}
