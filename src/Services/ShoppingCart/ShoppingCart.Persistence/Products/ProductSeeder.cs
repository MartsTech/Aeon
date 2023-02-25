using ShoppingCart.Domain.Categories;
using ShoppingCart.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Persistence.Products;

public static class ProductSeeder
{
    public static void SeedData(ModelBuilder builder)
    {
        if (builder == null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        var factory = new EntityFactory();

        Category fruitCategory = factory.NewCategory("Fruits");
        Category vegetableCategory = factory.NewCategory("Vegetables");

        builder.Entity<Category>().HasData(fruitCategory, vegetableCategory);

        builder.Entity<Product>().HasData(
            factory.NewProduct("Orange", "Orange fruit", 2, 0, fruitCategory.Id, "", 2),
            factory.NewProduct("Apple", "Red fruit", 3, 0, fruitCategory.Id, "", 3),
            factory.NewProduct("Cucumber", "Green vegetable", 4, 0, vegetableCategory.Id, "", 1),
            factory.NewProduct("Tomato", "Red vegetable", 1, 0, vegetableCategory.Id, "", 6));
    }
}