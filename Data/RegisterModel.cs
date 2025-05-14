using System.ComponentModel.DataAnnotations;

//Where user registers
//Attributes needed when registering
public class RegisterModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }


    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

}
