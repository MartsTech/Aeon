namespace Catalog.Domain.Categories
{
    public interface ICategory
    {
        public Guid Id { get; }
        public string Name { get; }
    }
}