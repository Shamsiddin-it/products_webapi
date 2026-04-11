using Domain.DTOs.Product;
using Domain.Interfaces;
using Domain.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService productService) : ControllerBase
    {
        private readonly IProductService service = productService;

        [HttpPost]
        public async Task<Response<string>> CreateProductAsync(CreateProductDto dto)
        {
            return await service.CreateProductAsync(dto);
        }

        [HttpDelete("{id:int}")]
        public async Task<Response<string>> DeleteProductAsync(int id)
        {
            return await service.DeleteProductAsync(id);
        }

        [HttpGet("{id:int}")]
        public async Task<Response<ProductDto>> GetProductAsync(int id)
        {
            return await service.GetProductAsync(id);
        }

        [HttpGet]
        public async Task<Response<List<ProductDto>>> GetProductsAsync()
        {
            return await service.GetProductsAsync();
        }

        [HttpPut("{id:int}")]
        public async Task<Response<string>> UpdateProductAsync(int id, UpdateProductDto dto)
        {
            return await service.UpdateProductAsync(id, dto);
        }
    }
}
