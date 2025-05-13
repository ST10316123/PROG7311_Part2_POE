using System.ComponentModel.DataAnnotations;

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
