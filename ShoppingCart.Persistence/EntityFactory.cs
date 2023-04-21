using ShoppingCart.Domain;
using ShoppingCart.Domain.ShoppingCarts;

namespace Catalog.Persistence;

public class EntityFactory : IEntityFactory
{

    public ShoppingCart NewShoppingCart(Guid id)
    {
        return new ShoppingCart(Guid.NewGuid(), id);
    }

}
