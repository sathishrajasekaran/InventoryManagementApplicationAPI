namespace InventoryManagementAPI.DTOs;

public class ProductUpdateDTO
{
    public string ProductName { get; set; } = string.Empty;
    public decimal price { get; set; }
    public int quantity { get; set; }
    public DateOnly ManufacturedDate { get; set; }
    public int Reportlevel { get; set; }
}