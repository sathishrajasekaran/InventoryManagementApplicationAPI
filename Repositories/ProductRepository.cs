using InventoryManagementAPI.Data;
using InventoryManagementAPI.Models;
using InventoryManagementAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using InventoryManagementAPI.DTOs;

namespace InventoryManagementAPI.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetallProductsAsync()
    {
        return await _context.Products.Include(p => p.Category).ToListAsync();
    }

    public async Task<Product?> GetProductsByIDAysnc(int id)
    {
        return  await _context.Products.FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Product> AddNewProductsAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        _context.SaveChanges();
        return product;
    }

    public Category? GetById(int ID)
    {
        return _context.Categories.FirstOrDefault(s => s.CategoryID == ID);
    }

    public async Task<Boolean> DeleteProductsAsync(int id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(s => s.Id == id);
        if (product != null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
        else
        {
            return false;
        }
    }

    public async Task<Product?> UpdateProductAsync(int id, ProductUpdateDTO product)
    {
        var existingProduct = await _context.Products.FirstOrDefaultAsync(s => s.Id == id);
        if (existingProduct != null)
        {
            existingProduct.ProductName = product.ProductName;
            existingProduct.price = product.price;
            existingProduct.quantity = product.quantity;
            existingProduct.ManufacturedDate = product.ManufacturedDate;
            existingProduct.Reportlevel = product.Reportlevel;
            await _context.SaveChangesAsync();
            return existingProduct;
        }
        else
        {
            return null;
        }
    }
} 

