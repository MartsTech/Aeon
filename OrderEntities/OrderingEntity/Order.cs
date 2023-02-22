using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEntities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int OrderNumber { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public int Zipcode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public string OrderDate { get; set; }
        public bool IsDelivered { get; set; }
        public bool EmailSent { get; set; }

        public List<OrderLine> OrderLines { get; set; }
    }
}
