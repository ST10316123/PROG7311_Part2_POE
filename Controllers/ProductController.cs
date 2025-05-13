using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROG7311_Part2_POE_1.Data;


public class ProductController : Controller
{
    private readonly IWebHostEnvironment _env;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ApplicationDbContext _context;

    public ProductController(IWebHostEnvironment env, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
    {
        _env = env;
        _userManager = userManager;
        _context = context;
    }


    [Authorize(Roles = "Farmer")]
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }


    [Authorize(Roles = "Farmer")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateProductViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        string uniqueFileName = null;
        if (model.ImageFile != null)
        {
            string uploadsFolder = Path.Combine(_env.WebRootPath, "images");    //writes address into wwwroot/images folder
            Directory.CreateDirectory(uploadsFolder);   // ensure folder exists
            uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImageFile.FileName;    //provides a unique file name
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);  //writes full path to the image
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await model.ImageFile.CopyToAsync(fileStream);
            }
        }

        var user = await _userManager.GetUserAsync(User);

        var product = new Product
        {
            Name = model.Name,
            Category = model.Category,
            ProductionDate = model.ProductionDate,
            ImagePath = "/images/" + uniqueFileName,
            FarmerId = user.Id
        };

        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return RedirectToAction("MyProducts");
    }


    [Authorize(Roles = "Employee")]
public async Task<IActionResult> AllProducts()
{
    var groupedProducts = await _context.Products
        .Include(p => p.Farmer)
        .GroupBy(p => new { p.FarmerId, p.Farmer.FirstName, p.Farmer.LastName })
        .Select(g => new FarmerProductGroupViewModel
        {
            FarmerName = g.Key.FirstName + " " + g.Key.LastName,
            Products = g.Select(p => new ProductListViewModel
            {
                Name = p.Name,
                Category = p.Category,
                ProductionDate = p.ProductionDate,
                ImagePath = p.ImagePath,
                FarmerName = g.Key.FirstName + " " + g.Key.LastName
            }).ToList()
        })
        .ToListAsync();

    return View(groupedProducts);
}


    [Authorize(Roles = "Farmer")]
    public async Task<IActionResult> MyProducts()
    {
        var userId = _userManager.GetUserId(User); // gets the currently logged-in user's ID

        var products = await _context.Products
            .Where(p => p.FarmerId == userId)
            .Select(p => new ProductListViewModel
            {
                Name = p.Name,
                Category = p.Category,
                ProductionDate = p.ProductionDate,
                ImagePath = p.ImagePath,
                FarmerName = "" 
            })
            .ToListAsync();

        return View(products);
    }


}
