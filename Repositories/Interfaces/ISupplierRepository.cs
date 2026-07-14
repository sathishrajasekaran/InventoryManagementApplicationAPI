namespace InventoryManagementAPI.Repositories.Interfaces;
using InventoryManagementAPI.Models;

public interface ISupplierRepository
{
    Task<Supplier> CreateNewSupplierAsync(Supplier supplier);
    Task<IEnumerable<Supplier>> GetAllSuppliersAsync();
}