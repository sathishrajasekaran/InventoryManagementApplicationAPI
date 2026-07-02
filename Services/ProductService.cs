using InventoryManagementAPI.Models;
using InventoryManagementAPI.Services.Interfaces;
using InventoryManagementAPI.Repositories.Interfaces;
using InventoryManagementAPI.DTOs;

namespace InventoryManagementAPI.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repo;
    
    public ProductService(IProductRepository repo)
    {
        _repo = repo;
    }
    public async Task<List<Product>> GetallProductsAsync()
    {
        return await _repo.GetallProductsAsync();
    }

    public async Task<Product?> GetProductsByIDAsync(int id)
    {
        return await _repo.GetProductsByIDAysnc(id);
    }

    public async Task<ProductCreateDTO> AddNewProductsAsync(ProductCreateDTO dto)
    {   
        //Business Logic
        //Validations
        //DTO to Entity
        //Calls Repository

        var category = _repo.GetById(dto.CategoryId);

        if (category == null)
        {
            throw new Exception("Catrgory Not Found");
        }
        var Newproduct = new Product
        {
            ProductName = dto.ProductName,
            price = dto.Price,
            quantity =dto.Quantity,
            CategoryId = dto.CategoryId,
            Reportlevel = dto.Reportlevel
        };
        var products = await _repo.AddNewProductsAsync(Newproduct);

        return new ProductCreateDTO
        {
            ProductName = products.ProductName,
            Price =products.price,
            Quantity = products.quantity,
            CategoryId = products.CategoryId,
            Reportlevel = products.Reportlevel
        };
    }

    public Task<bool> DeleteProductsAsync(int id)
    {
        var Deleted=_repo.DeleteProductsAsync(id);
        return Deleted;
    }

    public async Task<Product?> UpdateProductAsync(int id, ProductUpdateDTO product)
    {
        var updatedProduct = await _repo.UpdateProductAsync(id, product);
        if (updatedProduct != null)
            return updatedProduct;
        
        return null;
    }
}