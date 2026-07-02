using InventoryManagementAPI.Models;
using InventoryManagementAPI.DTOs;

namespace InventoryManagementAPI.Repositories.Interfaces;

public interface IProductRepository
{
    public Task<List<Product>> GetallProductsAsync();
    public Task<Product?> GetProductsByIDAysnc(int id);
    public Task<Product> AddNewProductsAsync(Product product );
    Category? GetById(int id);
    Task<Boolean> DeleteProductsAsync(int id);
    Task<Product?> UpdateProductAsync(int id, ProductUpdateDTO product);
}