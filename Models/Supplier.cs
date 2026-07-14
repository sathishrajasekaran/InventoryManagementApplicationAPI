namespace InventoryManagementAPI.Models;

public class Supplier
{
    public int? SupplierId {get;set;}
    public String SupplierName {get;set;} = string.Empty;
    public string ContactNumber {get;set;}= string.Empty;
    public string Email {get;set;}= string.Empty;
}