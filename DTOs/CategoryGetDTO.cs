namespace InventoryManagementAPI.DTOs;

public class CategoryGetDTO
{
    public int CategoryID { get; set; }

    public string CategoryName { get; set; } = string.Empty;

    public ICollection<ProductGetDTO> Products { get; set; } = new List<ProductGetDTO>();
}