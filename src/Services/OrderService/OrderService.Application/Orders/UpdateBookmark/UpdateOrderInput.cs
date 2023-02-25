using System.ComponentModel.DataAnnotations;

namespace OrderService.Application.Orders.UpdateOrder
{
    public class UpdateOrderInput
    {
        [Required] public Guid Id { get; set; }
        [Required] public int Quantity { get; set; }
    }
}