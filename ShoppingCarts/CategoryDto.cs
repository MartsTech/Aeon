using Catalog.Application.Products;
using Catalog.Domain.Categories;

namespace Catalog.Application.Categories
{
    public sealed record CategoryDto : ICategory
    {
        public CategoryDto(Category category)
        {
            Id = category.Id;
            Name = category.Name;
            Products = category.Products.Select(p => new ProductDto(p)).ToList();
        }

        public Guid Id { get; }
        public string Name { get; }
        public ICollection<ProductDto> Products { get; }
    }
}
