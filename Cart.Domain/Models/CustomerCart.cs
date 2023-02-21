using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Domain.Models
{
    public sealed class CustomerCart
    {
        public Guid Id { get; set; }

        public int CustomerId { get; set; }

        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public int TotalItems { get; set; }

        public decimal Subtotal { get; set; }
    }
}
