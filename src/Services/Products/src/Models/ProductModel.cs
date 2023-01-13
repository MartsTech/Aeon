using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Products.Models
{
    public class ProductModel
    {
        [ReadOnly(true)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
