using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace PalletIQ.SharedKernel.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception while processing request {Path}", context.Request.Path);

                if (context.Response.HasStarted)
                {
                    _logger.LogWarning("The response has already started, the error handler cannot modify the response.");
                    throw;
                }

                await HandleExceptionAsync(context, ex);
            }

        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var (statusCode, code, message) = ex switch
            {
                UnauthorizedAccessException => (401, "Unauthorized", "You are not authorized"),
                KeyNotFoundException => (404, "NotFound", "The request resource was not found"),
                ArgumentException e => (400, "BadRequest", e.Message),
                InvalidOperationException e => (422, "UnporcessableEntity", e.Message),
                _ => (500, "InternalServerError", "An unexpected Error occured")
            };

            context.Response.Clear();
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            var response = new
            {
                StatusCode = statusCode,
                Code = code,
                Message = message,
                Detail = ex?.Message,
                TraceId = context.TraceIdentifier,
                Timestamp = DateTime.UtcNow
            };

            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var payload = JsonSerializer.Serialize(response, options);
            await context.Response.WriteAsync(payload);
        }
    }
}
