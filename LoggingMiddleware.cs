// LoggingMiddleware.cs
using Microsoft.AspNetCore.Http;
using System.Diagnostics;

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;

    public LoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();

        Debug.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");

        await _next(context);

        stopwatch.Stop();
        Debug.WriteLine($"Response: {context.Response.StatusCode} (Elapsed Time: {stopwatch.ElapsedMilliseconds}ms)");
    }
}
