using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Products.Data;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ProductDbContext>
{
    public ProductDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<ProductDbContext>();

        builder.UseSqlServer("Server=localhost;Database=FlightDB;User ID=sa;Password=@Aa123456;TrustServerCertificate=True");
        return new ProductDbContext(builder.Options, null);
    }
}