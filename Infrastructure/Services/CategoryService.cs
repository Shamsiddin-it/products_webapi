using System;
using System.Net;
using Dapper;
using Domain.DTOs.Category;
using Domain.Interfaces;
using Domain.Responses;
using Infrastructure.Data;

namespace Infrastructure.Services;

public class CategoryService(ApplicationDbContext dbContext) : ICategoryService
{
    private readonly ApplicationDbContext context = dbContext;
    public async Task<Response<string>> CreateCategoryAsync(CreateCategoryDto dto)
    {
        using var connection = context.Connection();
        var query = "insert into categories(name, description) values(@name, @description)";
        var res = await connection.ExecuteAsync(query, dto);
        return res==0
        ? new Response<string>(HttpStatusCode.InternalServerError, "Something went wrong!")
        : new Response<string>(HttpStatusCode.OK, "Added successfully!");
    }

    public async Task<Response<string>> DeleteCategoryAsync(int id)
    {
        using var connection = context.Connection();
        var query = "delete from categories where id=@id";
        var res = await connection.ExecuteAsync(query, new {id});
        return res==0
        ? new Response<string>(HttpStatusCode.InternalServerError, "Something went wrong!")
        : new Response<string>(HttpStatusCode.OK, "Deleted successfully!");
    }

    public async Task<Response<List<CategoryDto>>> GetCategoriesAsync()
    {
        using var connection = context.Connection();
        var query = "select * from categories";
        var res = await connection.QueryAsync<CategoryDto>(query);
        return new Response<List<CategoryDto>>(HttpStatusCode.OK, "List of cateogries", res.ToList());
    }

    public async Task<Response<CategoryDto>> GetCategoryAsync(int id)
    {
        using var connection = context.Connection();
        var query = "select * from categories where id=@id";
        var res = await connection.QuerySingleAsync<CategoryDto>(query);
        return new Response<CategoryDto>(HttpStatusCode.OK, $"Category with id {id}", res);
    }

    public async Task<Response<string>> UpdateCategoryAsync(int id, UpdateCategoryDto dto)
    {
        using var connection = context.Connection();
        var query = "update categories set name=@name, description=@description where id=@id";
        var res = await connection.ExecuteAsync(query, new{dto, id});
        return res==0
        ? new Response<string>(HttpStatusCode.InternalServerError, "Something went wrong!")
        : new Response<string>(HttpStatusCode.OK, "Updated successfully!");
    }
}
