using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PalletIQ.SharedKernel.Abstractions;
using PalletIQ.SharedKernel.Constants;
using PalletIQ.SharedKernel.Context;

namespace PalletIQ.SharedKernel.Middlewares
{
    public class TenantContextMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<TenantContextMiddleware> _logger;

        public TenantContextMiddleware(RequestDelegate next, ILogger<TenantContextMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        private static readonly List<string> _publicPaths = new()
        {
            "/health",
            "/metrics",
            "/favicon.ico"
        };

        public async Task InvokeAsync(HttpContext context, ITenantContext tenantContext)
        {
            var path = context.Request.Path.Value ?? string.Empty;
            if (_publicPaths.Any(p => path.StartsWith(p, StringComparison.OrdinalIgnoreCase)))
            {
                _logger.LogDebug("Skipping tenant resolution for public path: {Path}", path);
                await _next(context);
                return; 
            }
            // Tenant resolution logic would go here (e.g., from headers, query, etc.)
            var tenantIdClaim = context.User.FindFirst(PalletIQClaims.TenantId);

            if (tenantIdClaim is null || !Guid.TryParse(tenantIdClaim.Value, out var tenantId))
            {
                _logger.LogWarning("Tenant ID claim is missing or invalid for path: {Path}", path);
                await WriteErroResponseAsync(context, StatusCodes.Status401Unauthorized, "InvalidTenant", "Tenant ID is missing or invalid.");
                return;

            }

            var tenantName = context.User.FindFirst(PalletIQClaims.TenantName)?.Value ?? string.Empty;

            var plan = context.User.FindFirst(PalletIQClaims.Plan)?.Value ?? string.Empty;

            ((TenantContext)tenantContext).SetTenant(tenantId, tenantName, plan);

            _logger.LogInformation($"Tenant resolved -> Id : {tenantId} | Plan : {plan}");
            await _next(context);
        }
    

    private static async Task WriteErroResponseAsync(HttpContext context, int statusCode, string code, string message)
        {
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";
            var response = JsonSerializer.Serialize(new
            {
                StatusCode = statusCode,
                Code = code,
                Message = message,
                TraceId = context.TraceIdentifier,
                Timestamp = DateTime.UtcNow
            });
            await context.Response.WriteAsync(response);

        }
    }
}
