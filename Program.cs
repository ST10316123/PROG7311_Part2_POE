using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PROG7311_Part2_POE_1.Data;

var builder = WebApplication.CreateBuilder(args);


// Adds DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adds Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = "/Auth/AccessDenied";
    
});


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


// **Seeder Execution:**
// using (var scope = app.Services.CreateScope())
// {
//     var services = scope.ServiceProvider;
//     var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
//     var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
//     var context = services.GetRequiredService<ApplicationDbContext>();
//     var env = services.GetRequiredService<IWebHostEnvironment>();

//     // Call the seeders to add the data
//     await EmployeeSeeder.SeedAsync(userManager, roleManager);
//     await FarmerSeeder.SeedAsync(userManager, roleManager);
//     await ProductSeeder.SeedAsync(context, userManager, env);
// }

app.Run();
