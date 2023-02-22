using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace OrderService.Application
{
    public class AddOrderInput
    {
        [Required] public Guid ProductId { get; set; }
        [Required] public int Quantity { get; set; }
        [Required] public Guid ListId { get; set; }
    }
}
