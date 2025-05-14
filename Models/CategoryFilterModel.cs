using System.ComponentModel.DataAnnotations;

//model class responsible for filtering the products based on categories and date range
public class CategoryFilterModel
{
    public string? Category { get; set; }

    [DataType(DataType.Date)]
    public DateTime? StartDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime? EndDate { get; set; }


    //holds multiple products that fit within a category
    public List<ProductListViewModel> Products { get; set; } = new();
    
    //holds the list of categories from products added
    public List<string> Categories { get; set; } = new();
}
