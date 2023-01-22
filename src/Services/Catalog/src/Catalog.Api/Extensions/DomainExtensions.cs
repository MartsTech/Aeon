using Catalog.Domain;
using Catalog.Domain.Categories;
using Catalog.Domain.Products;
using Catalog.Persistence;
using Catalog.Persistence.Categories;
using Catalog.Persistence.Products;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Api.Extensions;

public static class DomainExtensions
{
    public static IServiceCollection AddCustomDomain(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CatalogDbContext>(options =>
        {
            var connection = "Server=(localdb)\\MSSQLLocalDB;Database=ProductsDB;Trusted_Connection=True;MultipleActiveResultSets=true";
            options.UseSqlServer(connection);
        });
        
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IEntityFactory, EntityFactory>();

        return services;
    }
}