using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Domain.Models
{
    public sealed class Product
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string PackshotImageUrl { get; set; }

        public decimal UnitPrice { get; set; }

        public int QuantityAvailable { get; set; }
    }
}
