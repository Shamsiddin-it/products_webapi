using System;
using System.Net;

namespace Domain.Responses;

public class Response<T>
{
    public HttpStatusCode StatusCode {get; set;}
    public string? Message {get; set;}
    public T? Data {get; set;}

    public Response(HttpStatusCode statusCode, string message, T data)
    {
        StatusCode = statusCode;
        Message = message;
        Data = data;    
    }
    public Response(HttpStatusCode statusCode, string message)
    {
        StatusCode = statusCode;
        Message = message;
    }
}
