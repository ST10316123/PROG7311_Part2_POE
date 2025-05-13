using Microsoft.AspNetCore.Identity;
using PROG7311_Part2_POE_1.Data;
using PROG7311_Part2_POE_1.Models;

public class ProductSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IWebHostEnvironment env)
    {
        var farmer1 = await userManager.FindByEmailAsync("John@mail.com");
        var farmer2 = await userManager.FindByEmailAsync("Jane@mail.com");

        var products = new List<Product>
        {
            new Product
            {
                Name = "Tomatoes",
                Category = "Fruits",
                ProductionDate = DateTime.Now.AddMonths(-1),
                ImagePath = "/images/tomatoes.jpg",
                FarmerId = farmer1.Id
            },
            new Product
            {
                Name = "Avocadoes",
                Category = "Fruits",
                ProductionDate = DateTime.Now.AddMonths(-1),
                ImagePath = "/images/avocadoes.jpg",
                FarmerId = farmer1.Id
            },
            new Product
            {
                Name = "Cabbages",
                Category = "Vegetables",
                ProductionDate = DateTime.Now.AddMonths(-2),
                ImagePath = "/images/cabbages.jpg",
                FarmerId = farmer1.Id
            },
            new Product
            {
                Name = "Pineapples",
                Category = "Fruits",
                ProductionDate = DateTime.Now.AddMonths(0),
                ImagePath = "/images/Pineapples.jpg",
                FarmerId = farmer1.Id
            },
            new Product
            {
                Name = "Chicken Eggs",
                Category = "Animal Products",
                ProductionDate = DateTime.Now.AddMonths(1),
                ImagePath = "/images/Pineapples.jpg",
                FarmerId = farmer1.Id
            },
            new Product
            {
                Name = "Beef",
                Category = "Meat",
                ProductionDate = DateTime.Now.AddMonths(-2),
                ImagePath = "/images/beef.jpg",
                FarmerId = farmer1.Id
            },
            new Product
            {
                Name = "Honey",
                Category = "Natural Products",
                ProductionDate = DateTime.Now.AddMonths(3),
                ImagePath = "/images/honey.jpg",
                FarmerId = farmer2.Id
            },
            new Product
            {
                Name = "Red Kidney Beans",
                Category = "Legumes",
                ProductionDate = DateTime.Now.AddMonths(1),
                ImagePath = "/images/kidney-beans.jpg",
                FarmerId = farmer2.Id
            },
            new Product
            {
                Name = "Milk",
                Category = "Dairy",
                ProductionDate = DateTime.Now.AddMonths(-2),
                ImagePath = "/images/milk.jpg",
                FarmerId = farmer2.Id
            }

        };

        if (!context.Products.Any())
        {
            context.Products.AddRange(products);
            await context.SaveChangesAsync();
        }
    }
}
