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

            /*public int OrderId { get; set; }
        
        public string FullName { get; set; }
        public string Address { get; set; }
        public int Zipcode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string OrderDate { get; set; }
        public bool IsDelivered { get; set; }
        public bool EmailSent { get; set; }*/
    }

        public Guid Id { get; }
        public Guid ProductId { get; }
        public int ProductQuantity { get; set; }
        public DateOnly DateAdded { get; }
        public Guid UserId { get; }
        public Guid ListId { get; }
        
    }
}
