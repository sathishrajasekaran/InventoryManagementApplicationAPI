namespace InventoryManagementAPI.Models;

public class User
{
    public int UserId {get;set;}
    public String UserName {get;set;} = string.Empty;
    public string Password {get;set;} = string.Empty;
    public string Role {get;set;} = string.Empty;
}