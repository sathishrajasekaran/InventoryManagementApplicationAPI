namespace InventoryManagementAPI.Services.Interfaces;
using InventoryManagementAPI.Models;
public interface ISupplierService
{
    Task<Supplier> CreateNewSupplierAsync(Supplier supplier);
    Task<IEnumerable<Supplier>> GetAllSuppliersAsync();
}