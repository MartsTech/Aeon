namespace Catalog.Domain.Categories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategories(bool includeProducts);
        Task<Category?> GetCategoryById(Guid id);
        Task<Category?> GetCategoryByName(string name);
        Task AddCategory(Category category);
        Task<bool> UpdateCategoryName(Guid id, string newName);
        Task<bool> DeleteCategory(Guid id);
    }
}
