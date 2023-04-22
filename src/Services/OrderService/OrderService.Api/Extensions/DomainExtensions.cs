using OrderService.Domain;
using OrderService.Domain.Orders;
using OrderService.Domain.OrderLists;
using OrderService.Persistence;
using OrderService.Persistence.Orders;
using OrderService.Persistence.OrderLists;
using BuildingBlocks.EFCore;
using BuildingBlocks.Web;
using global::OrderService.Domain.Orders;
using global::OrderService.Domain.OrderLists;
using global::OrderService.Persistence.Orders;
using global::OrderService.Persistence.OrderLists;
using global::OrderService.Persistence;
using Microsoft.EntityFrameworkCore;

namespace OrderService.Api.Extensions
{

    public static class DomainExtensions
    {
        public static IServiceCollection AddCustomDomain(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrdersDbContext>(options =>
            {
                var mysql = configuration.GetOptions<MySQLOptions>("MySQLOptions");
                var connection =
                    $"Server={mysql.Host}; Port={mysql.Port}; Database={mysql.Database}; Uid={mysql.User}; Pwd={mysql.Password};";
                options.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 31)),
                    builder => { builder.EnableRetryOnFailure(); });
            });

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderListRepository, OrderListRepository>();
            services.AddScoped<IEntityFactory, EntityFactory>();

            return services;
        }
    }
}