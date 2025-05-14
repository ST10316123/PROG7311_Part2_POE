using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{

    //Additional user details to save besides username and password
    public string FirstName { get; set; }
    public string LastName { get; set; }
    

}
