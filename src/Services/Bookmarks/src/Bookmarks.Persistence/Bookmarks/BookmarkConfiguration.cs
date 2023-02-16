using Bookmarks.Domain.Bookmarks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookmarks.Persistence.Bookmarks
{
    internal class BookmarkConfiguration : IEntityTypeConfiguration<Bookmark>
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