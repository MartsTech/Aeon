using Cart.Domain.Carts;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cart.Domain.Carts
{
    public class Item : IItem
    {
        public Item(Guid id, Guid productId, int productQuantity, DateOnly dateAdded, Guid userId, Guid listId)
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
        public ShoppingCart List { get; }
    }
}
