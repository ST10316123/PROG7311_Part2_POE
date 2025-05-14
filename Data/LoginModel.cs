using System.ComponentModel.DataAnnotations;

//Where user logs in
//Details needed when logging in
public class LoginModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

}
