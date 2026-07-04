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

    public async Task<List<CategoryGetDTO>> GetAllCategoryAsync()
    {
        var categories = await _repo.GetAllCategoryAsync();
        if(categories == null || categories.Count == 0)
        {
            return new List<CategoryGetDTO>();
        }
        return categories.Select(c => new CategoryGetDTO
        {
            CategoryID = c.CategoryID,
            CategoryName = c.CategoryName,
            Products = c.Products.Select(p => new ProductGetDTO
            {
                ProductID = p.Id,
                ProductName = p.ProductName,
                price = p.price,
                quantity = p.quantity,
                CategoryName = c.CategoryName,
                Reportlevel = p.Reportlevel
            }).ToList()
        }).ToList();

    }
}