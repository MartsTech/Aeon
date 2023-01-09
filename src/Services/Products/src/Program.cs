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
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwagger();
            builder.Services.AddAuthentication(builder.Configuration);
            builder.Services.AddDbContext<ProductsDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IProductService, ProductService>();

            var app = builder.Build();

            app.UseSwagger(app.Environment);

            app.UseAuthorization();
            app.UseAuthentication();

            app.MapControllers();

            app.Run();
        }
    }
}