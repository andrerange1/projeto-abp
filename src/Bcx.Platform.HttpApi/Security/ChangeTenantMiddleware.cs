using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy;

namespace Bcx.Platform.Security
{
    public class ChangeTenantMiddleware : IMiddleware, ITransientDependency
    {
        private readonly ICurrentTenant _currentTenant;
        private readonly IOptions<ChangeTenantOptions> _options;

        public ChangeTenantMiddleware(
            ICurrentTenant currentTenant,
            IOptions<ChangeTenantOptions> options)
        {
            _currentTenant = currentTenant;
            _options = options;
        }

        [AllowAnonymous]
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var tenantId = FindTenantIdOnHeader(context);

            using (_currentTenant.Change(tenantId))
            {
                await next(context);
            }
        }

        private Guid? FindTenantIdOnHeader(HttpContext context)
        {
            var headerTenant = context.Request.Headers[_options.Value.TenantHeaderKey].FirstOrDefault();

            return headerTenant.IsNullOrEmpty() ? (Guid?)null : new Guid(headerTenant);
        }
    }
}
