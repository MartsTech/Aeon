using BuildingBlocks.Authentication;
using BuildingBlocks.Swagger;
using Microsoft.EntityFrameworkCore;
using Products.Data;
using Products.Services;

namespace Products
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddCustomSwagger();
            builder.Services.AddCustomAuthentication(builder.Configuration);
            builder.Services.AddDbContext<ProductsDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IProductService, ProductService>();

            var app = builder.Build();

            app.UseCustomSwagger();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}