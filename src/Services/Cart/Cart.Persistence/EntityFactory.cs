using Cart.Domain;
using Cart.Domain.Carts;
namespace Cart.Persistence
{

    public class EntityFactory : IEntityFactory
    {

        public ShoppingCart NewShoppingCart(Guid userId)
        {
            return new ShoppingCart(new Guid(), userId, DateOnly.FromDateTime(DateTime.Now));
        }

    }
}
