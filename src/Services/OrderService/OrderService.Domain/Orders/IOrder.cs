using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Domain.Orders
{
    public interface IOrder
    {
        public Guid Id { get; }
        public Guid ProductId { get; }
        public int ProductQuantity { get; }
        public DateOnly DateAdded { get; }
        public Guid UserId { get; }
    }
}
