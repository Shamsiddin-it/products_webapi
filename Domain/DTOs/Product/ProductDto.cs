using System;

namespace Domain.DTOs.Product;

public class ProductDto
{
    public int Id {get; set;}
    public int CategoryId {get; set;}
    public string Name {get; set;}=null!;
    public string Description {get; set;}=null!;
    public decimal Price {get; set;}
}
