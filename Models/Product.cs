using System;
using System.ComponentModel.DataAnnotations;

public class Product
{
    public int Id { get; set; }

    [Required]
    public string FarmerId { get; set; } // Foreign key to ApplicationUser

    [Required]
    public string Name { get; set; }

    [Required]
    public string Category { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime ProductionDate { get; set; }

    public string ImagePath { get; set; }

    public ApplicationUser Farmer { get; set; } // Navigation property
}
