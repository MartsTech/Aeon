using Catalog.Domain.Categories;
using Catalog.Domain.Products;

namespace Catalog.Domain;

public interface IEntityFactory
{
    Product NewProduct(string title, string? description, decimal price, decimal? discount, Guid categoryId,
        string? image, int quantity);

    Product NewProductWithExistingId(Guid id, string title, string? description, decimal price, decimal? discount,
        Guid categoryId,
        string? image, int quantity);

    Category NewCategory(string name);

    Category NewCategoryWithExistingId(Guid id, string name);
}