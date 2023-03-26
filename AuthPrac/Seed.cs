using AuthPrac.Data;
using AuthPrac.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthPrac
{
    public class Seed
    {
        public static async Task EnsurePopulatedAsync(IApplicationBuilder app)
        {
            AppDbContext appDbContext = app.ApplicationServices.CreateScope().ServiceProvider
                .GetRequiredService<AppDbContext>();

            if (!await appDbContext.Vendors.AnyAsync())
            {
                await appDbContext.Vendors.AddRangeAsync(VendorsWithProducts());
                await appDbContext.SaveChangesAsync();
            }
        }

        private static IEnumerable<Vendor>VendorsWithProducts()
        {
            return new List<Vendor>
            {
                new Vendor ()
                {
                  FullName = "John Doe",  Email = "john@example.com", Address = "123 Main St", PhoneNumber = "123-5555",

                  Products= new List<Product> {
                    new Product { ProductName = "Aquafina Water", Description = "Pure, refreshing bottled water",Price = 1.99m, Quantity = 5000},
                    new Product{ ProductName = "Swarm Water", Description = "Clear spring water", Price = 3.99m, Quantity = 3500},
                    new Product{ ProductName =  "Flavoured Water", Description = "Delicious, fruity flavored water", Price = 4.99m, Quantity = 4400} 
                  }
                },
               
                new Vendor ()
                {
                    FullName = "Jane Doe", Email = "jane2@example.com", Address = "456 Oak St", PhoneNumber = "456-7777",
                    Products = new List<Product> {
                    new Product { ProductName = "Idyllic Water", Description = "Fizzing, refreshing sparkling water",Price = 2.99m, Quantity = 7000},
                    new Product { ProductName = "Townhall Water", Description = "Nice sparkling water",Price = 1.99m, Quantity = 7000},
                    new Product { ProductName = "Eva Water", Description = "Refreshing drinking water",Price = 2.99m, Quantity = 8000},
                    new Product{ ProductName = "Swarm Water", Description = "Clear spring water", Price = 3.00m, Quantity = 7500} }

                },

                new Vendor()
                {
                    FullName = "Rick Doe", Email = "ricky3@example.com", Address = "789 Elm St", PhoneNumber = "890-1111",
                    Products = new List<Product> {
                    new Product { ProductName = "Idyllic Water", Description = "Fizzing, refreshing sparkling water",Price = 2.99m, Quantity = 9000},
                    new Product{ ProductName = "Swarm Water", Description = "Clear spring water", Price = 2.99m, Quantity = 5500} }
                }

            };

        }

               /* var vendor1 = new Vendor { FullName = "John Doe",  Email = "john@example.com", Address = "123 Main St", PhoneNumber = "123-5555",
                Products= new List<Product> { 
                    new Product { ProductName = "Aquafina Water", Description = "Pure, refreshing bottled water",Price = 1.99m, Quantity = 5000},
                    new Product{ ProductName = "Swarm Water", Description = "Clear spring water", Price = 3.99m, Quantity = 3500},
                    new Product{ ProductName =  "Flavoured Water", Description = "Delicious, fruity flavored water", Price = 4.99m, Quantity = 4400} }
                };

                var vendor2 = new Vendor { FullName = "Jane Doe", Email = "jane2@example.com", Address = "456 Oak St", PhoneNumber = "456-7777",
                    Products = new List<Product> { 
                    new Product { ProductName = "Idyllic Water", Description = "Fizzing, refreshing sparkling water",Price = 2.99m, Quantity = 7000},
                    new Product { ProductName = "Townhall Water", Description = "Nice sparkling water",Price = 1.99m, Quantity = 7000},
                    new Product { ProductName = "Eva Water", Description = "Refreshing drinking water",Price = 2.99m, Quantity = 8000},
                    new Product{ ProductName = "Swarm Water", Description = "Clear spring water", Price = 3.00m, Quantity = 7500} }
                };
                var vendor3 = new Vendor { FullName = "Rick Doe", Email = "ricky3@example.com", Address = "789 Elm St", PhoneNumber = "890-1111",
                    Products = new List<Product> { 
                    new Product { ProductName = "Idyllic Water", Description = "Fizzing, refreshing sparkling water",Price = 2.99m, Quantity = 9000},
                    new Product{ ProductName = "Swarm Water", Description = "Clear spring water", Price = 2.99m, Quantity = 5500} },
                    
                var customer1 = new Customer { FullName = "Franklin Saint", Email= "snowfall@example.com", Address = "10 Elm St", PhoneNumber = "555-5555" };
                var customer2 = new Customer { FullName = "Tyrese Hall", Email = "tyrese@example.com", Address = "20 Oak St", PhoneNumber = "555-5555" };
                var customer3 = new Customer { FullName = "Cuba Junior", Email = "junior@example.com", Address = "30 Main St", PhoneNumber = "555-5555" };

            
            */
    }
 }

