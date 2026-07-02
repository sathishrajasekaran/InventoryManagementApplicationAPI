using InventoryManagementAPI.Models;

namespace InventoryManagementAPI.DTOs;

public class ProductCreateDTO
{
    public string ProductName { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public int CategoryId { get; set; }

    public int Reportlevel {get;set;}

}