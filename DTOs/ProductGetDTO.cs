namespace InventoryManagementAPI.DTOs;

public class ProductGetDTO
{
    public int ProductID { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public decimal price   {get;set;}

    public int quantity {get;set;}

    public string CategoryName { get; set; } = string.Empty;

    public int Reportlevel {get;set;}
}