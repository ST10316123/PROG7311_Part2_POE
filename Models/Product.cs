using System;
using System.ComponentModel.DataAnnotations;

//Model that a database table is made from
public class Product
{

    //Unique ID
    public int Id { get; set; }

    [Required]
    public string FarmerId { get; set; } // Foreign key to Farmer (uses ApplicationUser to get ID)

    [Required]
    public string Name { get; set; }

    [Required]
    public string Category { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime ProductionDate { get; set; }

    //Saves image path as a string and not the image itself
    public string ImagePath { get; set; }


    public ApplicationUser Farmer { get; set; } // Navigation property
}
