using System.ComponentModel.DataAnnotations;

namespace Aeon.ShoppingCart
{
    public class CartItem
    {
        [Key]
        public string ItemId { get; set; }

        public int Name { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }

        public int Description { get; set; }

        public System.DateTime DateCreated { get; set; }

        public virtual Product Product { get; set; }

    }
}