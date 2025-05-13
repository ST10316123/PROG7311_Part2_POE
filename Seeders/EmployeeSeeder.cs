using Microsoft.AspNetCore.Identity;
using PROG7311_Part2_POE_1.Data;
using PROG7311_Part2_POE_1.Models;

public class EmployeeSeeder
{
    public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        const string employeeRole = "Employee";
        const string employeeEmail = "admin@farmershub.com";
        const string employeePassword = "Admin123!";

        // Check if the role exists; if not, create it
        if (!await roleManager.RoleExistsAsync(employeeRole))
        {
            await roleManager.CreateAsync(new IdentityRole(employeeRole));
        }

        var user = await userManager.FindByEmailAsync(employeeEmail);
        if (user == null)
        {
            user = new ApplicationUser
            {
                UserName = employeeEmail,
                Email = employeeEmail,
                FirstName = "Admin",
                LastName = "User"
            };

            var result = await userManager.CreateAsync(user, employeePassword);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, employeeRole);
            }
        }
    }
}
