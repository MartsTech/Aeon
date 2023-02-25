namespace ShoppingCart.Domain.Products
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProducts();
        Task<Product?> GetProductById(Guid id);
        Task AddProduct(Product product);
        Task<bool> UpdateProduct(Guid id, Product product);
        Task<bool> DeleteProduct(Guid id);
    }
}
