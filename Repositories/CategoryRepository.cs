namespace InventoryManagementAPI.Repositories;
using InventoryManagementAPI.Data;
using InventoryManagementAPI.Models;
using InventoryManagementAPI.DTOs;
using InventoryManagementAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _context;

    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Category> CreatenewCaterogyAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
        _context.SaveChanges();
        return category;
    }

    public async Task<List<Category>> GetAllCategoryAsync()
    {
       var categories = await _context.Categories.ToListAsync();
       return categories;
    }
}