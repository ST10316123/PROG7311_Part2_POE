using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

public class CreateProductViewModel
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Category { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime ProductionDate { get; set; }

    public IFormFile ImageFile { get; set; }
}
