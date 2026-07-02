namespace InventoryManagementAPI.Models;

public class Product
{
    public int Id {get;set;}
    public string ProductName {get;set;} = string.Empty ;
    public decimal price   {get;set;}
    public int quantity {get;set;}
    public DateOnly ManufacturedDate {get;set;}
    public int CategoryId {get;set;} //Foregin Key
    public int Reportlevel {get;set;}
    public Category ? Category {get;set;} // Navigation Property

}