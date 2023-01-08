using BuildingBlocks.Core.Event;

namespace Products.Products.Features.CreateProduct.Commands.Reads;

public record CreateProductMongoCommand(long Id, string Name, Enums.ProductType ProductType, bool IsDeleted) : InternalCommand;