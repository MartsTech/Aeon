using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEntities
{
    public class OrderLine
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int Qty { get; set; }
        public double PriceWhenBought { get; set; }
    }
}
