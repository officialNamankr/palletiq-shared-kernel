using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using PalletIQ.SharedKernel.Abstractions;
using PalletIQ.SharedKernel.Context;

namespace PalletIQ.SharedKernel.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSharedKernel (this IServiceCollection services)
        {
            services.AddHttpContextAccessor ();
            services.AddScoped<ITenantContext, TenantContext>();
            services.AddScoped<ICurrentUser, CurrentUser>();

            return services;
        }
    }
}
