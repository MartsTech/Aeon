﻿// <auto-generated />
using System;
using Bookmarks.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bookmarks.Persistence.Migrations
{
    [DbContext(typeof(BookmarksDbContext))]
    [Migration("20230216085635_AddBookmarksUserId.cs")]
    partial class AddBookmarksUserIdcs
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Bookmarks.Domain.Bookmarks.Bookmark", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateOnly>("DateAdded")
                        .HasColumnType("date");

                    b.Property<Guid>("ListId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("char(36)");

                    b.Property<int>("ProductQuantity")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ListId");

                    b.ToTable("Bookmarks");
                });

            modelBuilder.Entity("Bookmarks.Domain.Wishlists.Wishlist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateOnly>("DateCreated")
                        .HasColumnType("date");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("Wishlists");
                });

            modelBuilder.Entity("Bookmarks.Domain.Bookmarks.Bookmark", b =>
                {
                    b.HasOne("Bookmarks.Domain.Wishlists.Wishlist", "List")
                        .WithMany("Bookmarks")
                        .HasForeignKey("ListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("List");
                });

            modelBuilder.Entity("Bookmarks.Domain.Wishlists.Wishlist", b =>
                {
                    b.Navigation("Bookmarks");
                });
#pragma warning restore 612, 618
        }
    }
}