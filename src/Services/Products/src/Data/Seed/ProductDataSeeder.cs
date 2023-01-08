using BuildingBlocks.EFCore;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Products.Products.Enums;
using Products.Products.Models;
using Products.Products.Models.Reads;

namespace Products.Data.Seed;

public class ProductDataSeeder: IDataSeeder
{
    private readonly ProductDbContext _productDbContext;
    private readonly ProductReadDbContext _productReadDbContext;
    private readonly IMapper _mapper;
    
    public ProductDataSeeder(ProductDbContext flightDbContext,
        ProductReadDbContext flightReadDbContext,
        IMapper mapper)
    {
        _productDbContext = flightDbContext;
        _productReadDbContext = flightReadDbContext;
        _mapper = mapper;
    }
    
    public async Task SeedAllAsync()
    {
        await SeedProductAsync();
    }
    
    private async Task SeedProductAsync()
    {
        if (!await _productDbContext.Products.AnyAsync())
        {
            var airports = new List<Product>
            {
                Product.Create(1, "Lisbon International Airport", ProductType.Unknown, false),
            };

            await _productDbContext.Products.AddRangeAsync(airports);
            await _productDbContext.SaveChangesAsync();

            if (!await _productReadDbContext.Product.AsQueryable().AnyAsync())
                await _productReadDbContext.Product.InsertManyAsync(_mapper.Map<List<ProductReadModel>>(airports));
        }
    }
}