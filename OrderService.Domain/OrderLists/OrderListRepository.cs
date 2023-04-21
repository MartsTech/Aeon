namespace OrderService.Domain.OrderLists
{
    public interface IOrderListRepository
    {
        Task<List<OrderList>> GetAllLists(Guid userId, bool includeOrders);
        Task<OrderList?> GetListById(Guid userId, Guid id);
        Task CreateNewList(OrderList orderList);
        Task<bool> DeleteList(Guid id);
    }
