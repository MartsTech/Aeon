using Products.Data;
using Products.Data.Entities;
using Products.Models;

namespace Products.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductsDbContext _context;

        public ProductService(ProductsDbContext context)
        {
            _context = context;
        }

        public List<ProductModel> GetAllProducts()
        {
            return _context.Products.Select(ToModel).ToList();
        }

        public ProductModel? GetProductById(int id)
        {
            Product? product = GetProductEntityById(id);
            return product == null ? null : ToModel(product);
        }

        public void AddProduct(ProductModel product)
        {
            _context.Products.Add(ToEntity(product));
            _context.SaveChanges();
        }

        public bool UpdateProduct(int id, ProductModel product)
        {
            Product? dbProduct = GetProductEntityById(id);
            if (dbProduct == null)
            {
                return false;
            }

            dbProduct.Name = product.Name;
            dbProduct.Price = product.Price;

            _context.Products.Update(dbProduct);
            _context.SaveChanges();

            return true;
        }

        public bool DeleteProduct(int id)
        {
            Product? product = GetProductEntityById(id);
            if (product == null)
            {
                return false;
            }

            _context.Products.Remove(product);
            _context.SaveChanges();
            return true;
        }

        private ProductModel ToModel(Product product)
        {
            return new ProductModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }

        private Product ToEntity(ProductModel product)
        {
            return new Product
            {
                Name = product.Name,
                Price = product.Price
            };
        }

        private Product? GetProductEntityById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }
    }
}
