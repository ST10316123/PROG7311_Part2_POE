using System.ComponentModel.DataAnnotations;

//parent class
//created solely so that these attributes are not repeated in our other product model classes
public class BaseProductViewModel
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Category { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime ProductionDate { get; set; }
}
