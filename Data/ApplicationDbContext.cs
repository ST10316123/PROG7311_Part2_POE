using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace PROG7311_Part2_POE_1.Data;


//Links and creates tables for the database
//IdentityDbContext is inherited from and will create the User and Roles tables
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }


    //Products Table
    public DbSet<Product> Products { get; set; }


}
