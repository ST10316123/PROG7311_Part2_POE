
//also inherits from the base productviewmodel class
//created for views so it displays the farmer name

//farmer name was not an attribute in the Product model but this 
//separation of models displayes the usefulness of how 
//separate product classes can be used for specific purposes
//without altering the Product class
public class ProductListViewModel : BaseProductViewModel
{
    public string ImagePath { get; set; }
    public string FarmerName { get; set; }
    
}
