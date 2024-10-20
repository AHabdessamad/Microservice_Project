
using MongoDB.Bson;
using MongoDB.Driver;
using ProductService.Models;

namespace ProductService.Data
{
    public class ProductSeedData
    {
        public static void SeedData(IMongoCollection<Product> products)
        {
            bool Product = products.Find(p => true).Any();
            if(!Product)
            {
                products.InsertManyAsync(AddProducts());
            }
        }

        private static IEnumerable<Product> AddProducts()
        {
            var products = new List<Product>
            {
                new Product
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Name = "Wireless Mouse",
                    Category = "Electronics",
                    Description = "Ergonomic wireless mouse with 1600 DPI, 2.4 GHz connection.",
                    Brand = "Logitech",
                    Price = "29.99",
                    ImageFile = "wireless_mouse.jpg",
                    CreatedAt = DateTime.UtcNow,
                    Rating = 4.5f
                },
                new Product
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Name = "Bluetooth Headphones",
                    Category = "Audio",
                    Description = "Noise-cancelling over-ear headphones with 30-hour battery life.",
                    Brand = "Sony",
                    Price = "199.99",
                    ImageFile = "bluetooth_headphones.jpg",
                    CreatedAt = DateTime.UtcNow,
                    Rating = 4.7f
                },
                new Product
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Name = "Smartphone Stand",
                    Category = "Accessories",
                    Description = "Adjustable smartphone stand with anti-slip base and 360-degree rotation.",
                    Brand = "Ugreen",
                    Price = "14.99",
                    ImageFile = "smartphone_stand.jpg",
                    CreatedAt = DateTime.UtcNow,
                    Rating = 4.2f
                },
                new Product
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Name = "Gaming Keyboard",
                    Category = "Electronics",
                    Description = "Mechanical RGB backlit gaming keyboard with programmable keys.",
                    Brand = "Razer",
                    Price = "89.99",
                    ImageFile = "gaming_keyboard.jpg",
                    CreatedAt = DateTime.UtcNow,
                    Rating = 4.6f
                },
                new Product
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    Name = "4K Monitor",
                    Category = "Electronics",
                    Description = "27-inch 4K UHD monitor with HDR support and 144Hz refresh rate.",
                    Brand = "Dell",
                    Price = "399.99",
                    ImageFile = "4k_monitor.jpg",
                    CreatedAt = DateTime.UtcNow,
                    Rating = 4.8f
                }
                };

                return products;
        }
    }
}