using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

public class CreateProductViewModel : BaseProductViewModel
{
    public IFormFile ImageFile { get; set; }
    
}
