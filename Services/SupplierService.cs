namespace InventoryManagementAPI.Services;
using InventoryManagementAPI.Models;
using InventoryManagementAPI.Services.Interfaces;
using InventoryManagementAPI.Repositories.Interfaces;

public class SupplierService : ISupplierService
{
    private readonly ISupplierRepository SupplierRepository;
    public SupplierService(ISupplierRepository supplierRepository)
    {
        SupplierRepository = supplierRepository;
    }
    public async Task<Supplier> CreateNewSupplierAsync(Supplier supplier)
    {
        var newSupplier = new Supplier
        {
            SupplierName = supplier.SupplierName,
            ContactNumber = supplier.ContactNumber,
            Email = supplier.Email
        };
        return await SupplierRepository.CreateNewSupplierAsync(newSupplier);
    }

    public async Task<IEnumerable<Supplier>> GetAllSuppliersAsync()
    {
        return await SupplierRepository.GetAllSuppliersAsync();
    }
}
