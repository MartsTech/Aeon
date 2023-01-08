namespace Products.Products.Models.Reads;

public class ProductReadModel
{
    public long Id { get; init; }
    public long ProductId { get; init; }
    public string Name { get; init; }
    public Enums.ProductType ProductType { get; init; }
    public bool IsDeleted { get; init; }
}