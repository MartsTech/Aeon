using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderService.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderService.Domain
{
    public class Order : IOrder
    {
        public Order(Guid id, Guid productId, int productQuantity, DateOnly dateAdded, Guid userId, Guid listId)
        {
            Id = id;
            ProductId = productId;
            ProductQuantity = productQuantity;
            DateAdded = dateAdded;
            ListId = listId;
            UserId = userId;
        }

        public Guid Id { get; }
        public Guid ProductId { get; }
        public int ProductQuantity { get; set; }
        public DateOnly DateAdded { get; }
        public Guid UserId { get; }
        public Guid ListId { get; }
        
    }
}
