using BuildingBlocks.IdsGenerator;
using Mapster;
using Products.Products.Dtos;
using Products.Products.Models.Reads;

namespace Products.Products.Features;

public class ProductMappings:  IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Models.Product, ProductResponseDto>()
            .ConstructUsing(x => new ProductResponseDto(x.Id, x.Name, x.ProductType));

        config.NewConfig<Models.Product, ProductReadModel>()
            .Map(d => d.Id, s => SnowFlakIdGenerator.NewId())
            .Map(d => d.ProductId, s => s.Id);

        config.NewConfig<ProductReadModel, ProductResponseDto>()
            .Map(d => d.Id, s => s.ProductId);
    }
}