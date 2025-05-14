using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

//inherits from base Product view model
//Separate from Product class to allow for flexiblity
//this class is used to specifically add the image into the wwwroot/images/ folder
public class CreateProductViewModel : BaseProductViewModel
{
    public IFormFile ImageFile { get; set; }
    
}
