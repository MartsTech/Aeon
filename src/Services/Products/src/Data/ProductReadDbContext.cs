using BuildingBlocks.Mongo;
using Humanizer;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Products.Products.Models.Reads;

namespace Products.Data;

public class ProductReadDbContext: MongoDbContext
{
    public ProductReadDbContext(IOptions<MongoOptions> options) : base(options)
    {
        Product = GetCollection<ProductReadModel>(nameof(Product).Underscore());
    }
    
    public IMongoCollection<ProductReadModel> Product { get; }
}