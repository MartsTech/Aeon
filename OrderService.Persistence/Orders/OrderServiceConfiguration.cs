using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OrderService.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OrderService.Persistence
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Bookmark> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.Property(e => e.Id)
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.HasOne(b => b.List)
                .WithMany(l => l.Bookmarks)
                .HasForeignKey(b => b.ListId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(e => e.ProductQuantity)
                .IsRequired();

            builder.Property(e => e.ProductId).IsRequired();
            builder.Property(e => e.DateAdded).IsRequired();

            builder.Property(e => e.UserId).IsRequired();
        }
    }
}
