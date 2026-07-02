using InventoryManagementAPI.Models;
using InventoryManagementAPI.DTOs;

namespace InventoryManagementAPI.Services.Interfaces;

public interface IProductService
{
        Task<List<Product>> GetallProductsAsync();
        Task<Product?> GetProductsByIDAsync(int id);
        Task<ProductCreateDTO> AddNewProductsAsync(ProductCreateDTO product);
        Task<Boolean> DeleteProductsAsync(int id);
        Task<Product?> UpdateProductAsync(int id, ProductUpdateDTO product);
}