using Catalog.Domain.Categories;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Persistence.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CatalogDbContext _context;

        public CategoryRepository(CatalogDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllCategories(bool includeProducts)
        {
            return includeProducts
                ? await _context.Categories.Include(c => c.Products).ToListAsync().ConfigureAwait(false)
                : await _context.Categories.ToListAsync().ConfigureAwait(false);
        }

        public async Task<Category?> GetCategoryById(Guid id)
        {
            return await _context.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == id).ConfigureAwait(false);
        }

        public async Task<Category?> GetCategoryByName(string name)
        {
            return await _context.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.Name == name).ConfigureAwait(false);
        }

        public async Task AddCategory(Category category)
        {
            await _context.Categories.AddAsync(category).ConfigureAwait(false);
        }

        public async Task<bool> UpdateCategoryName(Guid id, string newName)
        {
            Category? category = await GetCategoryById(id).ConfigureAwait(false);
            if (category == null)
            {
                return false;
            }

            category.Name = newName;

            _context.Categories.Update(category);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return true;
        }

        public async Task<bool> DeleteCategory(Guid id)
        {
            Category? category = await GetCategoryById(id).ConfigureAwait(false);
            if (category == null || category.Products.Count > 0)
            {
                return false;
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return true;
        }
    }
}
