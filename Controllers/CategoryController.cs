using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using InventoryManagementAPI.Services;
using InventoryManagementAPI.Models;
using InventoryManagementAPI.DTOs;

namespace InventoryManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]

public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateNewCategoryAsync(CategoryCreateDTO category)
    {
        return Ok(await _categoryService.CreatenewCaterogyAsync(category));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCategoryAsync()
    {
        var Categories = await _categoryService.GetAllCategoryAsync();
        return Ok(Categories);
    }
}