public class MyMiddleware(RequestDelegate next,
        ILogger<MyMiddleware> logger)
{
    private readonly RequestDelegate _next=next;
    private readonly ILogger<MyMiddleware> _logger=logger;
    public async Task InvokeAsync(HttpContext context)
    {
        _logger.LogInformation(
            "Incoming request: {Method} {Path}",
            context.Request.Method,
            context.Request.Path);

        await _next(context);

        _logger.LogInformation(
            "Outgoing response: {StatusCode}",
            context.Response.StatusCode);
    }
}