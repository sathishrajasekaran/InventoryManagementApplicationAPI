using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using InventoryManagementAPI.Models;
using InventoryManagementAPI.Data;
using InventoryManagementAPI.Services.Interfaces;
using InventoryManagementAPI.DTOs;
using System.Threading.Tasks;

namespace InventoryManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _service.GetallProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductsByIDAsync(int id)
        {
            var product = await _service.GetProductsByIDAsync(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddProductsAsync(ProductCreateDTO product)
        {
            return Ok(await _service.AddNewProductsAsync(product));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductsAsync(int id)
        {
            var deleted = await _service.DeleteProductsAsync(id);
            if (deleted)
            {
                return Ok(
                    new
                    {   
                        success = true,
                        message = "Product Deleted Successfully"
                    }
                );
            }
            else
            {
                return NotFound(
                    new
                    {
                        success = false,
                        message = "Product Not Found"
                    }
                );
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductUpdateDTO product)
        {
            var updatedProduct = await _service.UpdateProductAsync(id, product);
            if (updatedProduct != null)
                return Ok(new
                {
                    success = true,
                    message = "Product updated Successfully",
                    data = updatedProduct
                });
            else
                return NotFound(new
                {
                    success = false,
                    message = "Product Not updated"
                });
        }

    }
}
