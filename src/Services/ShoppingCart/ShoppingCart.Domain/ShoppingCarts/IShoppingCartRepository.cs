namespace ShoppingCart.Domain.ShoppingCarts
{
    public interface IShoppingCartRepository
    {
        Task<List<ShoppingCart>> GetAllLists(Guid userId, bool includeProducts);
        Task<ShoppingCart?> GetListById(Guid userId, Guid id);
        Task CreateNewList(ShoppingCart shoppingCart);
        Task<bool> DeleteList(Guid id);
    }
}