using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.Domain.Products;

namespace ShoppingCart.Domain.ShoppingCarts
{
    public class ShoppingCart
    {
        public ShoppingCart(Guid id)
        {
            Id = id;
            Products = new List<Product>();
        }

        public Guid Id { get; }
        public ICollection<Product> Products { get; }
    }
}

