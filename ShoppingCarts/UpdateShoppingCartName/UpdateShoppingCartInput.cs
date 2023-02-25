using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Application.ShoppingCarts.UpdateShoppingCartName
{
    public class UpdateShoppingCartInput
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(90)]
        public string NewName { get; set; }
    }
}
