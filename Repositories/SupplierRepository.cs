namespace InventoryManagementAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using InventoryManagementAPI.Models;
using InventoryManagementAPI.Data;
using InventoryManagementAPI.Repositories.Interfaces;

public class SupplierRepository : ISupplierRepository
{
    private readonly AppDbContext _context;

    public SupplierRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Supplier> CreateNewSupplierAsync(Supplier supplier)
    {
        await _context.Suppliers.AddAsync(supplier);
        await _context.SaveChangesAsync();
        return supplier;
    }

    public async Task<IEnumerable<Supplier>> GetAllSuppliersAsync()
    {
        var suppliers = await _context.Suppliers.ToListAsync();
        return suppliers;
    }
}