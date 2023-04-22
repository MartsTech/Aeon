using OrderService.Domain.OrderLists;
using OrderService.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookmarks.Persistence.Wishlists
{
    public sealed class OrderListConfiguration : IEntityTypeConfiguration<OrderList>
    {
        public void Configure(EntityTypeBuilder<OrderList>builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.Property(e => e.Id)
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.Property(e => e.UserId)
                .IsRequired();

            builder.Property(e => e.DateCreated).IsRequired();

            builder.HasMany(l => l.Orders)
                .WithOne(b => b.List)
                .HasForeignKey(b => b.ListId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
