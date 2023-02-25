using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OrderService.Domain.Orders;
using BuildingBlocks.EFCore;
using Microsoft.EntityFrameworkCore;

namespace OrderService.Persistence
{
    public sealed class OrderServiceDbContext : DbContextBase
    {
        public OrderServiceDbContext(DbContextOptions options) : base(options)
        {
        }

       
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrdersDbContext).Assembly);
        }
    }
}
