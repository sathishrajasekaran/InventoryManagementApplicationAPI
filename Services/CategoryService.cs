namespace InventoryManagementAPI.Services;
using InventoryManagementAPI.Repositories.Interfaces;
using InventoryManagementAPI.Models;
using InventoryManagementAPI.DTOs;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repo;

    public CategoryService(ICategoryRepository repo)
    {
        _repo = repo ;

    }

    public async Task<Category> CreatenewCaterogyAsync(CategoryCreateDTO category)
    {
        var newCategory = new Category
        {
            CategoryName = category.CategoryName
        };
        return await _repo.CreatenewCaterogyAsync(newCategory);
    }

    public async Task<List<Category>> GetAllCategoryAsync()
    {
        return await _repo.GetAllCategoryAsync();
    }
}