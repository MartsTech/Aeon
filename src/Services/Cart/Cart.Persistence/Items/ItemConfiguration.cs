using Cart.Domain.Items;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookmarks.Persistence.Bookmarks
{
    internal class BookmarkConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.Property(e => e.Id)
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.HasOne(b => b.List)
                .WithMany(l => l.Items)
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
