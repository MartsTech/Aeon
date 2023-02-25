using System.ComponentModel.DataAnnotations;

namespace Catalog.Application.Categories.AddCategory
{
    public class CreateShoppinCartInput
    {
        [Required]
        [MaxLength(90)]
        public string Name { get; set; }
    }
}
