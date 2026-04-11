using System;
using System.Net;
using Dapper;
using Domain.DTOs.Product;
using Domain.Interfaces;
using Domain.Responses;
using Infrastructure.Data;

namespace Infrastructure.Services;

public class ProductService(ApplicationDbContext dbContext) : IProductService
{
    private readonly ApplicationDbContext context = dbContext;
    public async Task<Response<string>> CreateProductAsync(CreateProductDto dto)
    {
        using var connection = context.Connection();
        var query = "insert into products(categoryid, name, description, price) values(@categoryid, @name, @description, @price)";
        var res = await connection.ExecuteAsync(query, dto);
        return res==0
        ? new Response<string>(HttpStatusCode.InternalServerError, "Something went wrong!")
        : new Response<string>(HttpStatusCode.OK, "Added successfully!");
    }

    public async Task<Response<string>> DeleteProductAsync(int id)
    {
        using var connection = context.Connection();
        var query = "delete from products where id=@id";
        var res = await connection.ExecuteAsync(query, new {id});
        return res==0
        ? new Response<string>(HttpStatusCode.InternalServerError, "Something went wrong!")
        : new Response<string>(HttpStatusCode.OK, "Deleted successfully!");
    }

    public async Task<Response<List<ProductDto>>> GetProductsAsync()
    {
        using var connection = context.Connection();
        var query = "select * from products";
        var res = await connection.QueryAsync<ProductDto>(query);
        return new Response<List<ProductDto>>(HttpStatusCode.OK, "List of cateogries", res.ToList());
    }

    public async Task<Response<ProductDto>> GetProductAsync(int id)
    {
        using var connection = context.Connection();
        var query = "select * from products where id=@id";
        var res = await connection.QuerySingleAsync<ProductDto>(query);
        return new Response<ProductDto>(HttpStatusCode.OK, $"Product with id {id}", res);
    }

    public async Task<Response<string>> UpdateProductAsync(int id, UpdateProductDto dto)
    {
        using var connection = context.Connection();
        var query = "update products set categoryid=@categoryid, name=@name, description=@description, price=@price where id=@id";
        var res = await connection.ExecuteAsync(query, new{dto, id});
        return res==0
        ? new Response<string>(HttpStatusCode.InternalServerError, "Something went wrong!")
        : new Response<string>(HttpStatusCode.OK, "Updated successfully!");
    }
}
