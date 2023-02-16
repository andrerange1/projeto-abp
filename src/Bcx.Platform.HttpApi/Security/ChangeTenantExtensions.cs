using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Bcx.Platform.Security
{
    public static class ChangeTenantExtensions
    {
        public static IApplicationBuilder UseChangeTenant(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ChangeTenantMiddleware>();
        }

        public static IServiceCollection AddChangeTenant(this IServiceCollection services)
            => AddChangeTenant(services, options =>
                services.GetConfiguration()
                    .GetSection(ChangeTenantOptions.ChangeTenantSection).Bind(options));

        public static IServiceCollection AddChangeTenant(this IServiceCollection services, Action<ChangeTenantOptions> options = default)
        {
            options = options ?? (opts => new ChangeTenantOptions());
            return services.Configure(options);
        }
    }
}
