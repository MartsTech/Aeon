using Catalog.Domain.Categories;
using Catalog.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Persistence.Products;

public static class ProductSeeder
{
    public static void SeedData(ModelBuilder builder)
    {
        if (builder == null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        var factory = new EntityFactory();

        Category[] categories = new[]
        {
            factory.NewCategory("Kitchen appliances"),
            factory.NewCategory("TVs and entertainment"),
            factory.NewCategory("Mobile devices"),
            factory.NewCategory("Personal computers"),
            factory.NewCategory("Office equipment"),
            factory.NewCategory("Storage and hard drives"),
            factory.NewCategory("Photo and video cameras")
        };

        builder.Entity<Category>().HasData(categories);

        Random random = new();

        builder.Entity<Product>().HasData(
            factory.NewProduct("Electric Kettle with Stainless Steel Filter and Inner Lid", "1500W Wide Opening 1.7L Glass Tea Kettle & Hot Water Boiler, LED Indicator Auto Shut-Off & Boil-Dry Protection, BPA Free, Matte Black", 27.99m, 10, categories[0].Id, "https://m.media-amazon.com/images/I/81A4WeApjTL._AC_SL1500_.jpg", random.Next(0, 20)),
            factory.NewProduct("Air Fryer", "Crisps, Roasts, Reheats, & Dehydrates, for Quick, Easy Meals, 4 Quart Capacity, & High Gloss Finish, Black/Grey", 89.95m, 35, categories[0].Id, "https://m.media-amazon.com/images/I/71+8uTMDRFL._AC_SX679_.jpg", random.Next(0, 20)),
            factory.NewProduct("Digital Microwave Oven", "with Turntable Push-Button Door, Child Safety Lock, 700W, Stainless Steel, 0.7 Cu.ft", 80.10m, 20, categories[0].Id, "https://m.media-amazon.com/images/I/81gP22+jCVL._AC_SL1500_.jpg", random.Next(0, 20)),
            factory.NewProduct("SAMSUNG 32-inch Class LED Smart FHD TV 1080P", "Full HD 1080p Resolution - Enjoy a viewing experience that is 2x the clarity of standard HD TVs..Power Supply (V) AC110-120V 50/60Hz.Image Aspect ratio:16:9", 227.99m, 0, categories[1].Id, "https://m.media-amazon.com/images/I/91WxtFbQoBL._AC_SL1500_.jpg", random.Next(0, 20)),
            factory.NewProduct("Chromecast with Google TV (HD)", "Streaming Stick Entertainment on Your TV with Voice Search - Watch Movies, Shows, and Live TV in 1080p HD - Snow", 49.50m, 0, categories[1].Id, "https://m.media-amazon.com/images/I/51t2CkfmS5L._AC_SL1500_.jpg", random.Next(0, 20)),
            factory.NewProduct("Sony 32 Inch 720p HD LED HDR TV", "W830K Series with Google TV and Google Assistant-2022 Model", 348.00m, 6, categories[1].Id, "https://m.media-amazon.com/images/I/51RLq7+qIoL._AC_SL1200_.jpg", random.Next(0, 20)),
            factory.NewProduct("Apple iPhone 12", "64GB, Black - Fully Unlocked (Renewed)", 389.99m, 7, categories[2].Id, "https://m.media-amazon.com/images/I/71LM+uRWjML._AC_SL1500_.jpg", random.Next(0, 20)),
            factory.NewProduct("SAMSUNG Galaxy S20 FE 5G Cell Phone", "Factory Unlocked Android Smartphone, 128GB, Pro Grade Camera, 30X Space Zoom, Night Mode, US Version, Cloud Navy", 595.99m, 0, categories[2].Id, "https://m.media-amazon.com/images/I/71RxOftVoQL._AC_SL1500_.jpg", random.Next(0, 20)),
            factory.NewProduct("Pixel 4", "Clearly White - 64GB - Unlocked", 184.00m, 2, categories[2].Id, "https://m.media-amazon.com/images/I/71Ap5hKZoJL._AC_SL1500_.jpg", random.Next(0, 20)),
            factory.NewProduct("Lenovo 2022 Newest Ideapad 3 Laptop", "15.6 HD Touchscreen, 11th Gen Intel Core i3-1115G4 Processor, 8GB DDR4 RAM, 256GB PCIe NVMe SSD, HDMI, Webcam, Wi-Fi 5, Bluetooth, Windows 11 Home, Almond", 959.00m, 61, categories[3].Id, "https://m.media-amazon.com/images/I/61QGMX0Qy6L._AC_SL1352_.jpg", random.Next(0, 20)),
            factory.NewProduct("HP ENVY x360 Convertible 15-inch Laptop", "AMD Ryzen 7 5825U processor, AMD Radeon Graphics, 8 GB RAM, 512 GB SSD, Windows 11 Home (15-eu1026nr, Nightfall black aluminum)", 728.00m, 0, categories[3].Id, "https://m.media-amazon.com/images/I/71dv03iWcHL._AC_SL1500_.jpg", random.Next(0, 20)),
            factory.NewProduct("2017 Apple MacBook Air", "1.8GHz Intel Core i5 (13-inch, 8GB RAM, 128GB SSD Storage) (Renewed)", 344.00m, 5, categories[3].Id, "https://m.media-amazon.com/images/I/91wYB53Y4aL._AC_SL1500_.jpg", random.Next(0, 20)),
            factory.NewProduct("HP 63 Black Ink Cartridge", "Works with HP DeskJet 1112, 2130, 3630 Series; HP ENVY 4510, 4520 Series; HP OfficeJet 3830, 4650, 5200 Series | Eligible for Instant Ink | F6U62AN", 22.89m, 0, categories[4].Id, "https://m.media-amazon.com/images/I/71MHmk6IbBL._AC_SL1500_.jpg", random.Next(0, 20)),
            factory.NewProduct("Brother Genuine Standard Yield Toner Cartridge, TN730", "Replacement Black Toner, Page Yield Up To 1,200 Pages, Amazon Dash Replenishment Cartridge,1 Pack", 45.48m, 0, categories[4].Id, "https://m.media-amazon.com/images/I/7197bPYLO4L._AC_SL1500_.jpg", random.Next(0, 20)),
            factory.NewProduct("Fujitsu ScanSnap iX1600", "Wireless or USB High-Speed Cloud Enabled Document, Photo & Receipt Scanner with Large Touchscreen and Auto Document Feeder for Mac or PC, Black", 554.00m, 24, categories[4].Id, "https://m.media-amazon.com/images/I/71m+IpoL9kL._AC_SL1500_.jpg", random.Next(0, 20)),
            factory.NewProduct("Seagate Portable 2TB External Hard Drive HDD", "USB 3.0 for PC, Mac, PlayStation, & Xbox -1-Year Rescue Service (STGX2000400)", 61.99m, 0, categories[5].Id, "https://m.media-amazon.com/images/I/81tjLksKixL._AC_SL1500_.jpg", random.Next(0, 20)),
            factory.NewProduct("Seagate BarraCuda 4TB Internal Hard Drive HDD", "3.5 Inch Sata 6 Gb/s 5400 RPM 256MB Cache For Computer Desktop PC – Frustration Free Packaging ST4000DMZ04/DM004", 89.99m, 24, categories[5].Id, "https://m.media-amazon.com/images/I/71ijXHv0jHL._AC_SL1500_.jpg", random.Next(0, 20)),
            factory.NewProduct("WD 5TB Elements Portable HDD", "External Hard Drive, USB 3.0 for PC & Mac, Plug and Play Ready - WDBU6Y0050BBK-WESN", 129.99m, 19, categories[5].Id, "https://m.media-amazon.com/images/I/81WFWi9sKlL._AC_SL1500_.jpg", random.Next(0, 20)),
            factory.NewProduct("Canon EOS Rebel T7 DSLR Camera", "with 18-55mm Lens | Built-in Wi-Fi | 24.1 MP CMOS Sensor | DIGIC 4+ Image Processor and Full HD Videos", 479.00m, 17, categories[6].Id, "https://m.media-amazon.com/images/I/71EWRyqzw0L._AC_SL1500_.jpg", random.Next(0, 20)),
            factory.NewProduct("Canon PowerShot ELPH 360 Digital Camera", "w/ 12x Optical Zoom and Image Stabilization - Wi-Fi & NFC Enabled (Silver)", 299.99m, 0, categories[6].Id, "https://m.media-amazon.com/images/I/610WJy3fx5L._AC_SL1200_.jpg", random.Next(0, 20)),
            factory.NewProduct("KODAK PIXPRO Friendly Zoom FZ55-BK 16MP Digital Camera", "with 5X Optical Zoom 28mm Wide Angle and 2.7\" LCD Screen (Black)", 119.99m, 17, categories[6].Id, "https://m.media-amazon.com/images/I/81swjZCbdiL._AC_SL1500_.jpg", random.Next(0, 20))
            );
    }
}