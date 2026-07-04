using InventoryManagementAPI.Models;
using InventoryManagementAPI.DTOs;

namespace InventoryManagementAPI.Services;

public interface ICategoryService
{
    public Task<List<CategoryGetDTO>> GetAllCategoryAsync();
    public Task<Category> CreatenewCaterogyAsync(CategoryCreateDTO category);

}