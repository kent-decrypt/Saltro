using Microsoft.AspNetCore.Mvc;
using Saltro.Application.Exceptions;
using System.Text.Json;

namespace Saltro.Api.Middlewares;

/// <summary>
/// Contains the middleware for all the exceptions converting them to a ProblemDetails exception model.
/// </summary>
public class ExceptionsMiddleware(RequestDelegate next, ILogger<ExceptionsMiddleware> logger, IHostEnvironment environment)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<ExceptionsMiddleware> _logger = logger;
    private readonly IHostEnvironment _environment = environment;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ProblemDetailsException ex)
        {
            _logger.LogError(ex, ex.Details.Title);

            context.Response.StatusCode = ex.Details.Status.GetValueOrDefault(StatusCodes.Status500InternalServerError);
            context.Response.ContentType = "application/problem+json";

            var problemDetails = new ProblemDetails()
            {
                Status = ex.Details.Status,
                Title = ex.Details.Title,
                Detail = ex.Details.Detail,
                Type = ex.Details.Type ?? default,
                Instance = ex.Details.Instance ?? default,
            };

            if (ex.Details.Extensions != null && ex.Details.Extensions.Count > 0)
            {
                if (ex.Details.Extensions.TryGetValue("ErrorMessages", out var value))
                {
                    problemDetails.Extensions["errorMessages"] = value;
                }
            }

            await context.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
        }
        catch (Exception ex)
        {
            _logger.LogError("An exception has occurred. {ex}", ex);

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/problem+json";

            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "An error occurred while processing your request.",
                Detail = _environment.IsDevelopment() ? ex.StackTrace : "Please contact the administrator.",
                Instance = context.Request.Path
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
        }
    }
}

/// <summary>
/// Contains the extensions related to Exceptions Middleware
/// </summary>
public static class ExceptionsMiddlewareExtension
{
    /// <summary>
    /// Registers the Exceptions Middleware to the app's service
    /// </summary>
    /// <param name="app"></param>
    public static void AddExceptionMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionsMiddleware>();
    }
}