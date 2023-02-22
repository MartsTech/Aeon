using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEntities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public int AmountInStock { get; set; }
        public bool Featured { get; set; }

        public string Category { get; set; }

        public List<OrderLine> OrderLines { get; set; }
    }
}
