using System.ComponentModel.DataAnnotations;

namespace OrderService.Application.Orders.AddOrder
{
    public class AddOrderInput
    {
        [Required] public Guid ProductId { get; set; }
        [Required] public int Quantity { get; set; }
        [Required] public Guid ListId { get; set; }
    }
}