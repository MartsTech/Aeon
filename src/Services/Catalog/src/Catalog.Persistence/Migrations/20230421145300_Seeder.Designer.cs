﻿// <auto-generated />
using System;
using Catalog.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Catalog.Persistence.Migrations
{
    [DbContext(typeof(CatalogDbContext))]
    [Migration("20230421145300_Seeder")]
    partial class Seeder
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Catalog.Domain.Categories.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(90)
                        .HasColumnType("varchar(90)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1af1b96a-3c0b-4b58-aee9-cd223fefe45d"),
                            Name = "Kitchen appliances"
                        },
                        new
                        {
                            Id = new Guid("8d25fb94-d9f2-4d7a-83e6-c5183c6eadfb"),
                            Name = "TVs and entertainment"
                        },
                        new
                        {
                            Id = new Guid("acae7612-3839-4e5e-9b33-92aea238963d"),
                            Name = "Mobile devices"
                        },
                        new
                        {
                            Id = new Guid("71076d29-34c4-47ab-81b9-acff14af6a25"),
                            Name = "Personal computers"
                        },
                        new
                        {
                            Id = new Guid("495a4674-1f4e-4f1e-8d24-02108d5bab0b"),
                            Name = "Office equipment"
                        },
                        new
                        {
                            Id = new Guid("8cecacf8-0879-44cd-91f2-4948e6cd461e"),
                            Name = "Storage and hard drives"
                        },
                        new
                        {
                            Id = new Guid("e71cc7b4-5d9f-4594-8d67-eb76c7f3a1eb"),
                            Name = "Photo and video cameras"
                        });
                });

            modelBuilder.Entity("Catalog.Domain.Products.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<decimal?>("Discount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Image")
                        .HasColumnType("longtext");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(90)
                        .HasColumnType("varchar(90)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("46efaac6-736e-4947-bd68-b686dee3194e"),
                            CategoryId = new Guid("1af1b96a-3c0b-4b58-aee9-cd223fefe45d"),
                            Description = "1500W Wide Opening 1.7L Glass Tea Kettle & Hot Water Boiler, LED Indicator Auto Shut-Off & Boil-Dry Protection, BPA Free, Matte Black",
                            Discount = 10m,
                            Image = "https://m.media-amazon.com/images/I/81A4WeApjTL._AC_SL1500_.jpg",
                            Price = 27.99m,
                            Quantity = 7,
                            Title = "Electric Kettle with Stainless Steel Filter and Inner Lid"
                        },
                        new
                        {
                            Id = new Guid("4b46d1b6-bd08-4326-9607-b9658915f653"),
                            CategoryId = new Guid("1af1b96a-3c0b-4b58-aee9-cd223fefe45d"),
                            Description = "Crisps, Roasts, Reheats, & Dehydrates, for Quick, Easy Meals, 4 Quart Capacity, & High Gloss Finish, Black/Grey",
                            Discount = 35m,
                            Image = "https://m.media-amazon.com/images/I/71+8uTMDRFL._AC_SX679_.jpg",
                            Price = 89.95m,
                            Quantity = 3,
                            Title = "Air Fryer"
                        },
                        new
                        {
                            Id = new Guid("fde02e7b-2eac-4d52-8c54-19a13d1d1dc0"),
                            CategoryId = new Guid("1af1b96a-3c0b-4b58-aee9-cd223fefe45d"),
                            Description = "with Turntable Push-Button Door, Child Safety Lock, 700W, Stainless Steel, 0.7 Cu.ft",
                            Discount = 20m,
                            Image = "https://m.media-amazon.com/images/I/81gP22+jCVL._AC_SL1500_.jpg",
                            Price = 80.10m,
                            Quantity = 7,
                            Title = "Digital Microwave Oven"
                        },
                        new
                        {
                            Id = new Guid("ac6f94bb-0f05-46eb-928d-91112f8abdb0"),
                            CategoryId = new Guid("8d25fb94-d9f2-4d7a-83e6-c5183c6eadfb"),
                            Description = "Full HD 1080p Resolution - Enjoy a viewing experience that is 2x the clarity of standard HD TVs..Power Supply (V) AC110-120V 50/60Hz.Image Aspect ratio:16:9",
                            Discount = 0m,
                            Image = "https://m.media-amazon.com/images/I/91WxtFbQoBL._AC_SL1500_.jpg",
                            Price = 227.99m,
                            Quantity = 8,
                            Title = "SAMSUNG 32-inch Class LED Smart FHD TV 1080P"
                        },
                        new
                        {
                            Id = new Guid("17f32758-c566-483f-8c74-1bbb8655dfba"),
                            CategoryId = new Guid("8d25fb94-d9f2-4d7a-83e6-c5183c6eadfb"),
                            Description = "Streaming Stick Entertainment on Your TV with Voice Search - Watch Movies, Shows, and Live TV in 1080p HD - Snow",
                            Discount = 0m,
                            Image = "https://m.media-amazon.com/images/I/51t2CkfmS5L._AC_SL1500_.jpg",
                            Price = 49.50m,
                            Quantity = 7,
                            Title = "Chromecast with Google TV (HD)"
                        },
                        new
                        {
                            Id = new Guid("d69c592a-55ca-403b-8e57-bda433a41872"),
                            CategoryId = new Guid("8d25fb94-d9f2-4d7a-83e6-c5183c6eadfb"),
                            Description = "W830K Series with Google TV and Google Assistant-2022 Model",
                            Discount = 6m,
                            Image = "https://m.media-amazon.com/images/I/51RLq7+qIoL._AC_SL1200_.jpg",
                            Price = 348.00m,
                            Quantity = 5,
                            Title = "Sony 32 Inch 720p HD LED HDR TV"
                        },
                        new
                        {
                            Id = new Guid("64aa4636-ab0e-498d-9b47-82769d0044ca"),
                            CategoryId = new Guid("acae7612-3839-4e5e-9b33-92aea238963d"),
                            Description = "64GB, Black - Fully Unlocked (Renewed)",
                            Discount = 7m,
                            Image = "https://m.media-amazon.com/images/I/71LM+uRWjML._AC_SL1500_.jpg",
                            Price = 389.99m,
                            Quantity = 19,
                            Title = "Apple iPhone 12"
                        },
                        new
                        {
                            Id = new Guid("790cc17a-975b-4065-8ca7-582af85fd689"),
                            CategoryId = new Guid("acae7612-3839-4e5e-9b33-92aea238963d"),
                            Description = "Factory Unlocked Android Smartphone, 128GB, Pro Grade Camera, 30X Space Zoom, Night Mode, US Version, Cloud Navy",
                            Discount = 0m,
                            Image = "https://m.media-amazon.com/images/I/71RxOftVoQL._AC_SL1500_.jpg",
                            Price = 595.99m,
                            Quantity = 1,
                            Title = "SAMSUNG Galaxy S20 FE 5G Cell Phone"
                        },
                        new
                        {
                            Id = new Guid("c5f91da0-2bf0-4259-9c9e-3c0b310673c3"),
                            CategoryId = new Guid("acae7612-3839-4e5e-9b33-92aea238963d"),
                            Description = "Clearly White - 64GB - Unlocked",
                            Discount = 2m,
                            Image = "https://m.media-amazon.com/images/I/71Ap5hKZoJL._AC_SL1500_.jpg",
                            Price = 184.00m,
                            Quantity = 8,
                            Title = "Pixel 4"
                        },
                        new
                        {
                            Id = new Guid("baa953e8-34e2-4f91-b6c9-9e15b58ae5fe"),
                            CategoryId = new Guid("71076d29-34c4-47ab-81b9-acff14af6a25"),
                            Description = "15.6 HD Touchscreen, 11th Gen Intel Core i3-1115G4 Processor, 8GB DDR4 RAM, 256GB PCIe NVMe SSD, HDMI, Webcam, Wi-Fi 5, Bluetooth, Windows 11 Home, Almond",
                            Discount = 61m,
                            Image = "https://m.media-amazon.com/images/I/61QGMX0Qy6L._AC_SL1352_.jpg",
                            Price = 959.00m,
                            Quantity = 2,
                            Title = "Lenovo 2022 Newest Ideapad 3 Laptop"
                        },
                        new
                        {
                            Id = new Guid("a4b2c523-7040-4d03-aca6-b268f7f45831"),
                            CategoryId = new Guid("71076d29-34c4-47ab-81b9-acff14af6a25"),
                            Description = "AMD Ryzen 7 5825U processor, AMD Radeon Graphics, 8 GB RAM, 512 GB SSD, Windows 11 Home (15-eu1026nr, Nightfall black aluminum)",
                            Discount = 0m,
                            Image = "https://m.media-amazon.com/images/I/71dv03iWcHL._AC_SL1500_.jpg",
                            Price = 728.00m,
                            Quantity = 11,
                            Title = "HP ENVY x360 Convertible 15-inch Laptop"
                        },
                        new
                        {
                            Id = new Guid("8b507c88-7a2c-46fd-b86d-fec460f276ed"),
                            CategoryId = new Guid("71076d29-34c4-47ab-81b9-acff14af6a25"),
                            Description = "1.8GHz Intel Core i5 (13-inch, 8GB RAM, 128GB SSD Storage) (Renewed)",
                            Discount = 5m,
                            Image = "https://m.media-amazon.com/images/I/91wYB53Y4aL._AC_SL1500_.jpg",
                            Price = 344.00m,
                            Quantity = 3,
                            Title = "2017 Apple MacBook Air"
                        },
                        new
                        {
                            Id = new Guid("9a44d53a-0159-40a5-9619-7dc60e6186f7"),
                            CategoryId = new Guid("495a4674-1f4e-4f1e-8d24-02108d5bab0b"),
                            Description = "Works with HP DeskJet 1112, 2130, 3630 Series; HP ENVY 4510, 4520 Series; HP OfficeJet 3830, 4650, 5200 Series | Eligible for Instant Ink | F6U62AN",
                            Discount = 0m,
                            Image = "https://m.media-amazon.com/images/I/71MHmk6IbBL._AC_SL1500_.jpg",
                            Price = 22.89m,
                            Quantity = 17,
                            Title = "HP 63 Black Ink Cartridge"
                        },
                        new
                        {
                            Id = new Guid("34853b04-9483-433f-8fe9-9bcfebe63ffe"),
                            CategoryId = new Guid("495a4674-1f4e-4f1e-8d24-02108d5bab0b"),
                            Description = "Replacement Black Toner, Page Yield Up To 1,200 Pages, Amazon Dash Replenishment Cartridge,1 Pack",
                            Discount = 0m,
                            Image = "https://m.media-amazon.com/images/I/7197bPYLO4L._AC_SL1500_.jpg",
                            Price = 45.48m,
                            Quantity = 3,
                            Title = "Brother Genuine Standard Yield Toner Cartridge, TN730"
                        },
                        new
                        {
                            Id = new Guid("83f6da10-0ec5-431f-bb2c-7866acc11f52"),
                            CategoryId = new Guid("495a4674-1f4e-4f1e-8d24-02108d5bab0b"),
                            Description = "Wireless or USB High-Speed Cloud Enabled Document, Photo & Receipt Scanner with Large Touchscreen and Auto Document Feeder for Mac or PC, Black",
                            Discount = 24m,
                            Image = "https://m.media-amazon.com/images/I/71m+IpoL9kL._AC_SL1500_.jpg",
                            Price = 554.00m,
                            Quantity = 7,
                            Title = "Fujitsu ScanSnap iX1600"
                        },
                        new
                        {
                            Id = new Guid("5b7b41a3-d396-4a46-a3b7-36ca86752649"),
                            CategoryId = new Guid("8cecacf8-0879-44cd-91f2-4948e6cd461e"),
                            Description = "USB 3.0 for PC, Mac, PlayStation, & Xbox -1-Year Rescue Service (STGX2000400)",
                            Discount = 0m,
                            Image = "https://m.media-amazon.com/images/I/81tjLksKixL._AC_SL1500_.jpg",
                            Price = 61.99m,
                            Quantity = 16,
                            Title = "Seagate Portable 2TB External Hard Drive HDD"
                        },
                        new
                        {
                            Id = new Guid("5f4aec73-c5a8-4d6a-ba5d-ff082ff8038b"),
                            CategoryId = new Guid("8cecacf8-0879-44cd-91f2-4948e6cd461e"),
                            Description = "3.5 Inch Sata 6 Gb/s 5400 RPM 256MB Cache For Computer Desktop PC – Frustration Free Packaging ST4000DMZ04/DM004",
                            Discount = 24m,
                            Image = "https://m.media-amazon.com/images/I/71ijXHv0jHL._AC_SL1500_.jpg",
                            Price = 89.99m,
                            Quantity = 9,
                            Title = "Seagate BarraCuda 4TB Internal Hard Drive HDD"
                        },
                        new
                        {
                            Id = new Guid("507442d0-dd6a-4fb6-8ba6-92379b681c33"),
                            CategoryId = new Guid("8cecacf8-0879-44cd-91f2-4948e6cd461e"),
                            Description = "External Hard Drive, USB 3.0 for PC & Mac, Plug and Play Ready - WDBU6Y0050BBK-WESN",
                            Discount = 19m,
                            Image = "https://m.media-amazon.com/images/I/81WFWi9sKlL._AC_SL1500_.jpg",
                            Price = 129.99m,
                            Quantity = 6,
                            Title = "WD 5TB Elements Portable HDD"
                        },
                        new
                        {
                            Id = new Guid("5137e21c-ad7c-4175-b0c9-7d5392682e91"),
                            CategoryId = new Guid("e71cc7b4-5d9f-4594-8d67-eb76c7f3a1eb"),
                            Description = "with 18-55mm Lens | Built-in Wi-Fi | 24.1 MP CMOS Sensor | DIGIC 4+ Image Processor and Full HD Videos",
                            Discount = 17m,
                            Image = "https://m.media-amazon.com/images/I/71EWRyqzw0L._AC_SL1500_.jpg",
                            Price = 479.00m,
                            Quantity = 3,
                            Title = "Canon EOS Rebel T7 DSLR Camera"
                        },
                        new
                        {
                            Id = new Guid("575668c8-6402-4503-8ba9-60250f46b585"),
                            CategoryId = new Guid("e71cc7b4-5d9f-4594-8d67-eb76c7f3a1eb"),
                            Description = "w/ 12x Optical Zoom and Image Stabilization - Wi-Fi & NFC Enabled (Silver)",
                            Discount = 0m,
                            Image = "https://m.media-amazon.com/images/I/610WJy3fx5L._AC_SL1200_.jpg",
                            Price = 299.99m,
                            Quantity = 10,
                            Title = "Canon PowerShot ELPH 360 Digital Camera"
                        },
                        new
                        {
                            Id = new Guid("2cb4becf-69d5-475c-b4c3-74acd990e474"),
                            CategoryId = new Guid("e71cc7b4-5d9f-4594-8d67-eb76c7f3a1eb"),
                            Description = "with 5X Optical Zoom 28mm Wide Angle and 2.7\" LCD Screen (Black)",
                            Discount = 17m,
                            Image = "https://m.media-amazon.com/images/I/81swjZCbdiL._AC_SL1500_.jpg",
                            Price = 119.99m,
                            Quantity = 12,
                            Title = "KODAK PIXPRO Friendly Zoom FZ55-BK 16MP Digital Camera"
                        });
                });

            modelBuilder.Entity("Catalog.Domain.Products.Product", b =>
                {
                    b.HasOne("Catalog.Domain.Categories.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Catalog.Domain.Categories.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}