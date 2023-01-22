using System.ComponentModel.DataAnnotations;

namespace Catalog.Application.Categories.AddCategory
{
    public class CreateCategoryInput
    {
        [Required]
        [MaxLength(90)]
        public string Name { get; set; }
    }
}
