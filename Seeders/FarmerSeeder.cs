using Microsoft.AspNetCore.Identity;
using PROG7311_Part2_POE_1.Data;
using PROG7311_Part2_POE_1.Models;

public class FarmerSeeder
{
    public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        const string farmerRole = "Farmer";
        var farmers = new List<ApplicationUser>
        {
            new ApplicationUser { UserName = "John@mail.com", Email = "John@mail.com", FirstName = "John", LastName = "Doe" },
            new ApplicationUser { UserName = "Jane@mail.com", Email = "Jane@mail.com", FirstName = "Jane", LastName = "Smith" }
        };

        if (!await roleManager.RoleExistsAsync(farmerRole))
        {
            await roleManager.CreateAsync(new IdentityRole(farmerRole));
        }

        foreach (var farmer in farmers)
        {
            var user = await userManager.FindByEmailAsync(farmer.Email);
            if (user == null)
            {
                var result = await userManager.CreateAsync(farmer, "Farmer123!");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(farmer, farmerRole);
                }
            }
        }
    }
}
