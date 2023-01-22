using System.ComponentModel.DataAnnotations;

namespace Catalog.Application.Categories.UpdateCategoryName
{
    public class UpdateCategoryInput
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(90)]
        public string NewName { get; set; }
    }
}
