using Catalog.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Persistence.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly CatalogDbContext _context;

        public ProductRepository(CatalogDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync().ConfigureAwait(false);
        }

        public async Task<Product?> GetProductById(Guid id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id).ConfigureAwait(false);
        }

        public async Task AddProduct(Product product)
        {
            await _context.Products.AddAsync(product).ConfigureAwait(false);
        }

        public async Task<bool> UpdateProduct(Guid id, Product product)
        {
            Product? dbProduct = await GetProductById(id).ConfigureAwait(false);
            if (dbProduct == null)
            {
                return false;
            }

            dbProduct.Title = product.Title;
            dbProduct.Price = product.Price;
            dbProduct.Description = product.Description;
            dbProduct.CategoryId = product.CategoryId;
            dbProduct.Discount = product.Discount;
            dbProduct.Quantity = product.Quantity;
            dbProduct.Image = product.Image;

            _context.Products.Update(dbProduct);
            //await _context.SaveChangesAsync().ConfigureAwait(false);

            return true;
        }

        public async Task<bool> DeleteProduct(Guid id)
        {
            Product? product = await GetProductById(id).ConfigureAwait(false);
            if (product == null)
            {
                return false;
            }

            _context.Products.Remove(product);
            //await _context.SaveChangesAsync().ConfigureAwait(false);

            return true;
        }
    }
}
