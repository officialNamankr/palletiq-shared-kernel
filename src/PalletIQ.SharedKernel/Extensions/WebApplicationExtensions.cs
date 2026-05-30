using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using PalletIQ.SharedKernel.Middlewares;

namespace PalletIQ.SharedKernel.Extensions
{
    public static class WebApplicationExtensions
    {

        public static WebApplication UseSharedKernel(this WebApplication app)
        {
            // Global exception handling should run early in the pipeline
            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseAuthentication();

            app.UseAuthorization();

            // Tenant context should be resolved for subsequent middlewares and endpoints
            app.UseMiddleware<TenantContextMiddleware>();

            return app;
        }
    }
}
