using System;
using Domain.DTOs.Product;
using Domain.Responses;

namespace Domain.Interfaces;

public interface IProductService
{
    Task<Response<string>> CreateProductAsync(CreateProductDto dto);
    Task<Response<string>> DeleteProductAsync(int id);
    Task<Response<ProductDto>> GetProductAsync(int id);
    Task<Response<List<ProductDto>>> GetProductsAsync();
    Task<Response<string>> UpdateProductAsync(int id, UpdateProductDto dto);
}
