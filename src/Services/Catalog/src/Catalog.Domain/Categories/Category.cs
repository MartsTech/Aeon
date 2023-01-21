using Catalog.Domain.Products;

namespace Catalog.Domain.Categories
{
    public class Category : ICategory
    {
        public Category(Guid id, string name)
        {
            Id = id;
            Name = name;
            Products = new List<Product>();
        }

        public Guid Id { get; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; }
    }
}
