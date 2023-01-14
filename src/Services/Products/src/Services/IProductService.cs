using Products.Models;

namespace Products.Services
{
    public interface IProductService
    {
        List<ProductModel> GetAllProducts();
        ProductModel? GetProductById(int id);
        void AddProduct(ProductModel product);
        bool UpdateProduct(int id, ProductModel product);
        bool DeleteProduct(int id);
    }
}
