using Domain.DTOs.Category;
using Domain.Interfaces;
using Domain.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryService categoryService) : ControllerBase
    {
        private readonly ICategoryService service = categoryService;

        [HttpPost]
        public async Task<Response<string>> CreateCategoryAsync(CreateCategoryDto dto)
        {
            return await service.CreateCategoryAsync(dto);
        }

        [HttpDelete("{id:int}")]
        public async Task<Response<string>> DeleteCategoryAsync(int id)
        {
            return await service.DeleteCategoryAsync(id);
        }

        [HttpGet("{id:int}")]
        public async Task<Response<CategoryDto>> GetCategoryAsync(int id)
        {
            return await service.GetCategoryAsync(id);
        }

        [HttpGet]
        public async Task<Response<List<CategoryDto>>> GetCategoriesAsync()
        {
            return await service.GetCategoriesAsync();
        }

        [HttpPut("{id:int}")]
        public async Task<Response<string>> UpdateCategoryAsync(int id, UpdateCategoryDto dto)
        {
            return await service.UpdateCategoryAsync(id, dto);
        }
    }
}
