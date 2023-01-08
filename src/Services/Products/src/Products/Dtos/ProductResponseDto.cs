namespace Products.Products.Dtos;

public record ProductResponseDto
{
    public long Id { get; init; }
    public string Name { get; init; }
    public Enums.ProductType ProductType { get; init; }
}