using System;
using Domain.DTOs.Category;
using Domain.Responses;

namespace Domain.Interfaces;

public interface ICategoryService
{
    Task<Response<string>> CreateCategoryAsync(CreateCategoryDto dto);
    Task<Response<string>> DeleteCategoryAsync(int id);
    Task<Response<CategoryDto>> GetCategoryAsync(int id);
    Task<Response<List<CategoryDto>>> GetCategoriesAsync();
    Task<Response<string>> UpdateCategoryAsync(int id, UpdateCategoryDto dto);
}
