using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Catalog.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Seeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("02ea6906-3464-44b0-8280-b5057671b575"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("58e71a71-8f85-4c8d-bcac-3430e43e7413"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("65af12f2-82c9-45d4-8b27-d160f70a6ae2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9ee2fad3-5579-4e97-82e6-81d6e0afb702"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1d0238af-4f54-4411-b6f3-248c69193e05"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ea445d83-4def-4b12-8f18-f61638f2a9cb"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1af1b96a-3c0b-4b58-aee9-cd223fefe45d"), "Kitchen appliances" },
                    { new Guid("495a4674-1f4e-4f1e-8d24-02108d5bab0b"), "Office equipment" },
                    { new Guid("71076d29-34c4-47ab-81b9-acff14af6a25"), "Personal computers" },
                    { new Guid("8cecacf8-0879-44cd-91f2-4948e6cd461e"), "Storage and hard drives" },
                    { new Guid("8d25fb94-d9f2-4d7a-83e6-c5183c6eadfb"), "TVs and entertainment" },
                    { new Guid("acae7612-3839-4e5e-9b33-92aea238963d"), "Mobile devices" },
                    { new Guid("e71cc7b4-5d9f-4594-8d67-eb76c7f3a1eb"), "Photo and video cameras" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Discount", "Image", "Price", "Quantity", "Title" },
                values: new object[,]
                {
                    { new Guid("17f32758-c566-483f-8c74-1bbb8655dfba"), new Guid("8d25fb94-d9f2-4d7a-83e6-c5183c6eadfb"), "Streaming Stick Entertainment on Your TV with Voice Search - Watch Movies, Shows, and Live TV in 1080p HD - Snow", 0m, "https://m.media-amazon.com/images/I/51t2CkfmS5L._AC_SL1500_.jpg", 49.50m, 7, "Chromecast with Google TV (HD)" },
                    { new Guid("2cb4becf-69d5-475c-b4c3-74acd990e474"), new Guid("e71cc7b4-5d9f-4594-8d67-eb76c7f3a1eb"), "with 5X Optical Zoom 28mm Wide Angle and 2.7\" LCD Screen (Black)", 17m, "https://m.media-amazon.com/images/I/81swjZCbdiL._AC_SL1500_.jpg", 119.99m, 12, "KODAK PIXPRO Friendly Zoom FZ55-BK 16MP Digital Camera" },
                    { new Guid("34853b04-9483-433f-8fe9-9bcfebe63ffe"), new Guid("495a4674-1f4e-4f1e-8d24-02108d5bab0b"), "Replacement Black Toner, Page Yield Up To 1,200 Pages, Amazon Dash Replenishment Cartridge,1 Pack", 0m, "https://m.media-amazon.com/images/I/7197bPYLO4L._AC_SL1500_.jpg", 45.48m, 3, "Brother Genuine Standard Yield Toner Cartridge, TN730" },
                    { new Guid("46efaac6-736e-4947-bd68-b686dee3194e"), new Guid("1af1b96a-3c0b-4b58-aee9-cd223fefe45d"), "1500W Wide Opening 1.7L Glass Tea Kettle & Hot Water Boiler, LED Indicator Auto Shut-Off & Boil-Dry Protection, BPA Free, Matte Black", 10m, "https://m.media-amazon.com/images/I/81A4WeApjTL._AC_SL1500_.jpg", 27.99m, 7, "Electric Kettle with Stainless Steel Filter and Inner Lid" },
                    { new Guid("4b46d1b6-bd08-4326-9607-b9658915f653"), new Guid("1af1b96a-3c0b-4b58-aee9-cd223fefe45d"), "Crisps, Roasts, Reheats, & Dehydrates, for Quick, Easy Meals, 4 Quart Capacity, & High Gloss Finish, Black/Grey", 35m, "https://m.media-amazon.com/images/I/71+8uTMDRFL._AC_SX679_.jpg", 89.95m, 3, "Air Fryer" },
                    { new Guid("507442d0-dd6a-4fb6-8ba6-92379b681c33"), new Guid("8cecacf8-0879-44cd-91f2-4948e6cd461e"), "External Hard Drive, USB 3.0 for PC & Mac, Plug and Play Ready - WDBU6Y0050BBK-WESN", 19m, "https://m.media-amazon.com/images/I/81WFWi9sKlL._AC_SL1500_.jpg", 129.99m, 6, "WD 5TB Elements Portable HDD" },
                    { new Guid("5137e21c-ad7c-4175-b0c9-7d5392682e91"), new Guid("e71cc7b4-5d9f-4594-8d67-eb76c7f3a1eb"), "with 18-55mm Lens | Built-in Wi-Fi | 24.1 MP CMOS Sensor | DIGIC 4+ Image Processor and Full HD Videos", 17m, "https://m.media-amazon.com/images/I/71EWRyqzw0L._AC_SL1500_.jpg", 479.00m, 3, "Canon EOS Rebel T7 DSLR Camera" },
                    { new Guid("575668c8-6402-4503-8ba9-60250f46b585"), new Guid("e71cc7b4-5d9f-4594-8d67-eb76c7f3a1eb"), "w/ 12x Optical Zoom and Image Stabilization - Wi-Fi & NFC Enabled (Silver)", 0m, "https://m.media-amazon.com/images/I/610WJy3fx5L._AC_SL1200_.jpg", 299.99m, 10, "Canon PowerShot ELPH 360 Digital Camera" },
                    { new Guid("5b7b41a3-d396-4a46-a3b7-36ca86752649"), new Guid("8cecacf8-0879-44cd-91f2-4948e6cd461e"), "USB 3.0 for PC, Mac, PlayStation, & Xbox -1-Year Rescue Service (STGX2000400)", 0m, "https://m.media-amazon.com/images/I/81tjLksKixL._AC_SL1500_.jpg", 61.99m, 16, "Seagate Portable 2TB External Hard Drive HDD" },
                    { new Guid("5f4aec73-c5a8-4d6a-ba5d-ff082ff8038b"), new Guid("8cecacf8-0879-44cd-91f2-4948e6cd461e"), "3.5 Inch Sata 6 Gb/s 5400 RPM 256MB Cache For Computer Desktop PC – Frustration Free Packaging ST4000DMZ04/DM004", 24m, "https://m.media-amazon.com/images/I/71ijXHv0jHL._AC_SL1500_.jpg", 89.99m, 9, "Seagate BarraCuda 4TB Internal Hard Drive HDD" },
                    { new Guid("64aa4636-ab0e-498d-9b47-82769d0044ca"), new Guid("acae7612-3839-4e5e-9b33-92aea238963d"), "64GB, Black - Fully Unlocked (Renewed)", 7m, "https://m.media-amazon.com/images/I/71LM+uRWjML._AC_SL1500_.jpg", 389.99m, 19, "Apple iPhone 12" },
                    { new Guid("790cc17a-975b-4065-8ca7-582af85fd689"), new Guid("acae7612-3839-4e5e-9b33-92aea238963d"), "Factory Unlocked Android Smartphone, 128GB, Pro Grade Camera, 30X Space Zoom, Night Mode, US Version, Cloud Navy", 0m, "https://m.media-amazon.com/images/I/71RxOftVoQL._AC_SL1500_.jpg", 595.99m, 1, "SAMSUNG Galaxy S20 FE 5G Cell Phone" },
                    { new Guid("83f6da10-0ec5-431f-bb2c-7866acc11f52"), new Guid("495a4674-1f4e-4f1e-8d24-02108d5bab0b"), "Wireless or USB High-Speed Cloud Enabled Document, Photo & Receipt Scanner with Large Touchscreen and Auto Document Feeder for Mac or PC, Black", 24m, "https://m.media-amazon.com/images/I/71m+IpoL9kL._AC_SL1500_.jpg", 554.00m, 7, "Fujitsu ScanSnap iX1600" },
                    { new Guid("8b507c88-7a2c-46fd-b86d-fec460f276ed"), new Guid("71076d29-34c4-47ab-81b9-acff14af6a25"), "1.8GHz Intel Core i5 (13-inch, 8GB RAM, 128GB SSD Storage) (Renewed)", 5m, "https://m.media-amazon.com/images/I/91wYB53Y4aL._AC_SL1500_.jpg", 344.00m, 3, "2017 Apple MacBook Air" },
                    { new Guid("9a44d53a-0159-40a5-9619-7dc60e6186f7"), new Guid("495a4674-1f4e-4f1e-8d24-02108d5bab0b"), "Works with HP DeskJet 1112, 2130, 3630 Series; HP ENVY 4510, 4520 Series; HP OfficeJet 3830, 4650, 5200 Series | Eligible for Instant Ink | F6U62AN", 0m, "https://m.media-amazon.com/images/I/71MHmk6IbBL._AC_SL1500_.jpg", 22.89m, 17, "HP 63 Black Ink Cartridge" },
                    { new Guid("a4b2c523-7040-4d03-aca6-b268f7f45831"), new Guid("71076d29-34c4-47ab-81b9-acff14af6a25"), "AMD Ryzen 7 5825U processor, AMD Radeon Graphics, 8 GB RAM, 512 GB SSD, Windows 11 Home (15-eu1026nr, Nightfall black aluminum)", 0m, "https://m.media-amazon.com/images/I/71dv03iWcHL._AC_SL1500_.jpg", 728.00m, 11, "HP ENVY x360 Convertible 15-inch Laptop" },
                    { new Guid("ac6f94bb-0f05-46eb-928d-91112f8abdb0"), new Guid("8d25fb94-d9f2-4d7a-83e6-c5183c6eadfb"), "Full HD 1080p Resolution - Enjoy a viewing experience that is 2x the clarity of standard HD TVs..Power Supply (V) AC110-120V 50/60Hz.Image Aspect ratio:16:9", 0m, "https://m.media-amazon.com/images/I/91WxtFbQoBL._AC_SL1500_.jpg", 227.99m, 8, "SAMSUNG 32-inch Class LED Smart FHD TV 1080P" },
                    { new Guid("baa953e8-34e2-4f91-b6c9-9e15b58ae5fe"), new Guid("71076d29-34c4-47ab-81b9-acff14af6a25"), "15.6 HD Touchscreen, 11th Gen Intel Core i3-1115G4 Processor, 8GB DDR4 RAM, 256GB PCIe NVMe SSD, HDMI, Webcam, Wi-Fi 5, Bluetooth, Windows 11 Home, Almond", 61m, "https://m.media-amazon.com/images/I/61QGMX0Qy6L._AC_SL1352_.jpg", 959.00m, 2, "Lenovo 2022 Newest Ideapad 3 Laptop" },
                    { new Guid("c5f91da0-2bf0-4259-9c9e-3c0b310673c3"), new Guid("acae7612-3839-4e5e-9b33-92aea238963d"), "Clearly White - 64GB - Unlocked", 2m, "https://m.media-amazon.com/images/I/71Ap5hKZoJL._AC_SL1500_.jpg", 184.00m, 8, "Pixel 4" },
                    { new Guid("d69c592a-55ca-403b-8e57-bda433a41872"), new Guid("8d25fb94-d9f2-4d7a-83e6-c5183c6eadfb"), "W830K Series with Google TV and Google Assistant-2022 Model", 6m, "https://m.media-amazon.com/images/I/51RLq7+qIoL._AC_SL1200_.jpg", 348.00m, 5, "Sony 32 Inch 720p HD LED HDR TV" },
                    { new Guid("fde02e7b-2eac-4d52-8c54-19a13d1d1dc0"), new Guid("1af1b96a-3c0b-4b58-aee9-cd223fefe45d"), "with Turntable Push-Button Door, Child Safety Lock, 700W, Stainless Steel, 0.7 Cu.ft", 20m, "https://m.media-amazon.com/images/I/81gP22+jCVL._AC_SL1500_.jpg", 80.10m, 7, "Digital Microwave Oven" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("17f32758-c566-483f-8c74-1bbb8655dfba"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2cb4becf-69d5-475c-b4c3-74acd990e474"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("34853b04-9483-433f-8fe9-9bcfebe63ffe"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("46efaac6-736e-4947-bd68-b686dee3194e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4b46d1b6-bd08-4326-9607-b9658915f653"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("507442d0-dd6a-4fb6-8ba6-92379b681c33"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5137e21c-ad7c-4175-b0c9-7d5392682e91"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("575668c8-6402-4503-8ba9-60250f46b585"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5b7b41a3-d396-4a46-a3b7-36ca86752649"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5f4aec73-c5a8-4d6a-ba5d-ff082ff8038b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("64aa4636-ab0e-498d-9b47-82769d0044ca"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("790cc17a-975b-4065-8ca7-582af85fd689"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("83f6da10-0ec5-431f-bb2c-7866acc11f52"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8b507c88-7a2c-46fd-b86d-fec460f276ed"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9a44d53a-0159-40a5-9619-7dc60e6186f7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a4b2c523-7040-4d03-aca6-b268f7f45831"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ac6f94bb-0f05-46eb-928d-91112f8abdb0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("baa953e8-34e2-4f91-b6c9-9e15b58ae5fe"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c5f91da0-2bf0-4259-9c9e-3c0b310673c3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d69c592a-55ca-403b-8e57-bda433a41872"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fde02e7b-2eac-4d52-8c54-19a13d1d1dc0"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1af1b96a-3c0b-4b58-aee9-cd223fefe45d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("495a4674-1f4e-4f1e-8d24-02108d5bab0b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("71076d29-34c4-47ab-81b9-acff14af6a25"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8cecacf8-0879-44cd-91f2-4948e6cd461e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8d25fb94-d9f2-4d7a-83e6-c5183c6eadfb"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("acae7612-3839-4e5e-9b33-92aea238963d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e71cc7b4-5d9f-4594-8d67-eb76c7f3a1eb"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1d0238af-4f54-4411-b6f3-248c69193e05"), "Fruits" },
                    { new Guid("ea445d83-4def-4b12-8f18-f61638f2a9cb"), "Vegetables" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Discount", "Image", "Price", "Quantity", "Title" },
                values: new object[,]
                {
                    { new Guid("02ea6906-3464-44b0-8280-b5057671b575"), new Guid("1d0238af-4f54-4411-b6f3-248c69193e05"), "Orange fruit", 0m, "", 2m, 2, "Orange" },
                    { new Guid("58e71a71-8f85-4c8d-bcac-3430e43e7413"), new Guid("1d0238af-4f54-4411-b6f3-248c69193e05"), "Red fruit", 0m, "", 3m, 3, "Apple" },
                    { new Guid("65af12f2-82c9-45d4-8b27-d160f70a6ae2"), new Guid("ea445d83-4def-4b12-8f18-f61638f2a9cb"), "Green vegetable", 0m, "", 4m, 1, "Cucumber" },
                    { new Guid("9ee2fad3-5579-4e97-82e6-81d6e0afb702"), new Guid("ea445d83-4def-4b12-8f18-f61638f2a9cb"), "Red vegetable", 0m, "", 1m, 6, "Tomato" }
                });
        }
    }
}
