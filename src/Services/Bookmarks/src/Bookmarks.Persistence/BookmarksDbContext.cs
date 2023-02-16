using Bookmarks.Domain.Bookmarks;
using Bookmarks.Domain.Wishlists;
using BuildingBlocks.EFCore;
using Microsoft.EntityFrameworkCore;

namespace Bookmarks.Persistence
{
    public sealed class BookmarksDbContext : DbContextBase
    {
        public BookmarksDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<Bookmark> Bookmarks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookmarksDbContext).Assembly);
        }
    }
}