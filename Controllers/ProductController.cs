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

        //in this block of code, the CreateProductViewModel adds the image to inside the wwwroot/images/ folder
        //it also creates the image path which is saved as a string in the products table
        {
            string uploadsFolder = Path.Combine(_env.WebRootPath, "images");    //writes address into wwwroot/images folder
            Directory.CreateDirectory(uploadsFolder);   // ensure folder exists
            uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImageFile.FileName;    //provides a unique file name
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);  //writes full path to the image
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await model.ImageFile.CopyToAsync(fileStream);  //adds images to the folder
            }
        }

        var user = await _userManager.GetUserAsync(User);

        var product = new Product
        {
            Name = model.Name,
            Category = model.Category,
            ProductionDate = model.ProductionDate,
            ImagePath = "/images/" + uniqueFileName, //taken from the block of code above
            FarmerId = user.Id  //using UserManager to get the farmer ID
        };

        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return RedirectToAction("MyProducts");
    }


    //method for displaying the list of all farmer's products
    [Authorize(Roles = "Employee")]
    [HttpGet]
    public async Task<IActionResult> AllProducts(string category, DateTime? startDate, DateTime? endDate)
    {
        //Gets all distinct categories for the dropdown menu
        var categories = await _context.Products.Select(p => p.Category).Distinct().ToListAsync();

        //initializes a base query to get products and includes their related Farmer entity
        var query = _context.Products
            .Include(p => p.Farmer)
            .AsQueryable();

        // Apply filters if provided
        if (!string.IsNullOrEmpty(category))
        {
            //cheks for products where the inputted category matches the database product cateogry
            query = query.Where(p => p.Category == category);
        }

        if (startDate.HasValue)
        {
            query = query.Where(p => p.ProductionDate >= startDate.Value);
        }

        if (endDate.HasValue)
        {
            query = query.Where(p => p.ProductionDate <= endDate.Value);
        }


        //groups products into each farmers' one
        //lists products under each farmer
        var groupedProducts = await query.GroupBy(p => new { p.FarmerId, p.Farmer.FirstName, p.Farmer.LastName })
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

        var model = new CategoryFilterModel
        {
            Category = category,
            StartDate = startDate,
            EndDate = endDate,
            Categories = categories,
            Products = groupedProducts.SelectMany(g => g.Products).ToList()
        };

        //grooupedProducts contains all the filtered products
        ViewBag.GroupedProducts = groupedProducts;

        return View(model);
    }



    //Farmer views their own products
    [Authorize(Roles = "Farmer")]
    public async Task<IActionResult> MyProducts()
    {
        var userId = _userManager.GetUserId(User); // gets the currently logged-in user's ID

        var products = await _context.Products.Where(p => p.FarmerId == userId).Select(p => new ProductListViewModel
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
