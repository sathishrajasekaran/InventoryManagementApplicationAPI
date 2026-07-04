using InventoryManagementAPI.Models;
using InventoryManagementAPI.DTOs;

namespace InventoryManagementAPI.Services.Interfaces;

public interface IProductService
{
        Task<List<ProductGetDTO>> GetallProductsAsync();
        Task<ProductGetDTO?> GetProductsByIDAsync(int id);
        Task<ProductCreateDTO> AddNewProductsAsync(ProductCreateDTO product);
        Task<Boolean> DeleteProductsAsync(int id);
        Task<Product?> UpdateProductAsync(int id, ProductUpdateDTO product);
}