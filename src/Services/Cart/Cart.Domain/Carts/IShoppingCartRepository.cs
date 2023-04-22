using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Domain.Carts
{
    public interface IShoppingCartRepository
    {
        Task<List<ShoppingCart>> GetAllLists(Guid userId, bool includeProducts);
        Task<ShoppingCart?> GetListById(Guid userId, Guid id);
        Task CreateNewList(ShoppingCart shoppingCart);
        Task<bool> DeleteList(Guid id);
    }
}
