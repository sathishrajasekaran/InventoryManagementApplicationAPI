namespace InventoryManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using InventoryManagementAPI.Services.Interfaces;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class SupplierController : ControllerBase
{
    private readonly ISupplierService _supplierService;

    public SupplierController(ISupplierService supplierService)
    {
        _supplierService = supplierService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateNewSupplierAsync(Supplier supplier)
    {
        return Ok(await _supplierService.CreateNewSupplierAsync(supplier));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllSuppliersAsync()
    {
        var suppliers = await _supplierService.GetAllSuppliersAsync();
        return Ok(suppliers);
    }
}