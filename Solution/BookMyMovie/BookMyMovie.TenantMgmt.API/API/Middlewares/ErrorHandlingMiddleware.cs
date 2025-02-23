using BookMyMovie.TenantMgmt.API.API.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlingMiddleware> _logger;

    public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception has occurred.");
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        var routeValues = context.Request.RouteValues;
        var endpoint = context.GetEndpoint();
        var metadata = endpoint?.Metadata.GetMetadata<ActionDescriptionAttribute>();
        //var routeValues = endpoint.

        var response = new
        {
            context.Response.StatusCode,
            Message = "Internal Server Error. Please try again later.",
            Detailed = exception.Message, // You might want to remove this in production
            metadata.Description,
            Controller = routeValues["controller"] as string,
            Action = routeValues["action"] as string
        };

        return context.Response.WriteAsJsonAsync(response);
    }
}