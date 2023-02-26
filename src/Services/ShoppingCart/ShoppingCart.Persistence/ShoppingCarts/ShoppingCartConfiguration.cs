using ShoppingCart.Domain.ShoppingCarts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookmarks.Persistence.Wishlists
{
    public sealed class ShoppingCartConfiguration : IEntityTypeConfiguration<Wishlist>
    {
        public void Configure(EntityTypeBuilder<Wishlist> builder)
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
            
            builder.HasMany(l => l.Products)
                .WithOne(p => p.List)
                .HasForeignKey(b => b.ListId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}