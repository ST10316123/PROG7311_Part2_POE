using System.ComponentModel.DataAnnotations;

public class CategoryFilterModel
{
    public string? Category { get; set; }

    [DataType(DataType.Date)]
    public DateTime? StartDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime? EndDate { get; set; }

    public List<ProductListViewModel> Products { get; set; } = new();
    
    
    public List<string> Categories { get; set; } = new();
}
