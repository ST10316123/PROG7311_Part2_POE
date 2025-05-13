using Microsoft.AspNetCore.Identity;
using PROG7311_Part2_POE_1.Data;
using PROG7311_Part2_POE_1.Models;

public class ProductSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IWebHostEnvironment env)
    {
        var farmer1 = await userManager.FindByEmailAsync("farmer1@example.com");
        var farmer2 = await userManager.FindByEmailAsync("farmer2@example.com");

        var products = new List<Product>
        {
            new Product
            {
                Name = "Tomatoes",
                Category = "Vegetables",
                ProductionDate = DateTime.Now.AddMonths(-1),
                ImagePath = "/images/tomatoes.jpg",
                FarmerId = farmer1.Id
            },
            new Product
            {
                Name = "Cabbages",
                Category = "Vegetables",
                ProductionDate = DateTime.Now.AddMonths(-2),
                ImagePath = "/images/cabbages.jpg",
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
