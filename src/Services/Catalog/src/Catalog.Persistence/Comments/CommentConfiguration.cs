using Catalog.Domain.Comments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Persistence.Comments
{
    public sealed class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.Property(e => e.Id)
                .UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction);

            builder.Property(e => e.UserId)
                .IsRequired();

            builder.Property(e => e.Content)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasOne(p => p.Product)
                .WithMany(c => c.Comments)
                .HasForeignKey(p => p.ProductId)
                .IsRequired();

            builder.HasMany(e => e.Upvotes).WithOne(u => u.Comment).HasForeignKey(u => u.CommentId).IsRequired();
        }
    }
}
