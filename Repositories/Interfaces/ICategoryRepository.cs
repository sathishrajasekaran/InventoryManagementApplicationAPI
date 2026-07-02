namespace InventoryManagementAPI.Repositories.Interfaces;


using InventoryManagementAPI.Models;



public interface ICategoryRepository
{
    Task<Category> CreatenewCaterogyAsync(Category category);

    Task<List<Category>> GetAllCategoryAsync();

   
}