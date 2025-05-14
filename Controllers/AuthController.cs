using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using PROG7311_Part2_POE_1.Models;
using Microsoft.AspNetCore.Authorization;

//Manages the registration and login functions
public class AuthController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AuthController(
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager,
        SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _signInManager = signInManager;
    }

    //Routes user to page if user does not have access
    [HttpGet]
    public IActionResult AccessDenied()
    {
        return View();
    }

    //Ensures that only a user that has the role of an Employee can register a user
    //Aligns with project requirements
    [Authorize(Roles = "Employee")]
    // GET: Register form
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [Authorize(Roles = "Employee")]
    // POST: Register user
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var user = new ApplicationUser
        {
            UserName = model.Email,
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName
        };
        var result = await _userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {

            //constant role of Farmer is given here since Employee will only add farmers to the system
            const string farmerRole = "Farmer";

            if (!await _roleManager.RoleExistsAsync(farmerRole))
            {
                await _roleManager.CreateAsync(new IdentityRole(farmerRole));
            }

            await _userManager.AddToRoleAsync(user, farmerRole);
            
            return RedirectToAction("Index", "Home");
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError("", error.Description);
        }

        return View(model);
    }

    // GET: Login form
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    // POST: Login user
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

        if (result.Succeeded)
        {
            return RedirectToAction("Index", "Home");
        }

        ModelState.AddModelError("", "Invalid login attempt.");
        return View(model);
    }

    // Logs out user
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}
