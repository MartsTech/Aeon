using Catalog.Domain;
using Catalog.Domain.Categories;
using Catalog.Domain.Products;

namespace Catalog.Persistence
{
    public class EntityFactory : IEntityFactory
    {
        public Product NewProduct(string title, string? description, decimal price, decimal? discount,
            Guid categoryId,
            string? image, int quantity)
        {
            return new Product(Guid.NewGuid(), title, description, price, discount, categoryId, image, quantity);
        }

        public Product NewProductWithExistingId(Guid id, string title, string? description, decimal price,
            decimal? discount,
            Guid categoryId,
            string? image, int quantity)
        {
            return new Product(id, title, description, price, discount, categoryId, image, quantity);
        }

        public Category NewCategory(string name)
        {
            return new Category(Guid.NewGuid(), name);
        }

        public Category NewCategoryWithExistingId(Guid id, string name)
        {
            return new Category(id, name);
        }
    }
}
