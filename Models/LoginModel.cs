using System.ComponentModel.DataAnnotations;
using PROG7311_Part2_POE_1.Models;

public class LoginModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    public bool RememberMe { get; set; }
}
