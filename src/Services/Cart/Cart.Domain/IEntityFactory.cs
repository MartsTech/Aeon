using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cart.Domain.Carts;

namespace Cart.Domain
{
    public interface IEntityFactory
    {
        ShoppingCart NewShoppingCart(Guid userId);

    }
}
