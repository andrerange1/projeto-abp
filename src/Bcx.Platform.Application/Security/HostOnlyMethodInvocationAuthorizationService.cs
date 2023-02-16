using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Authorization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy;

namespace Bcx.Platform.Security
{
    public class HostOnlyMethodInvocationAuthorizationService : IMethodInvocationAuthorizationService, ITransientDependency
    {
        private readonly ICurrentTenant _currentTenant;
        private readonly IAbpAuthorizationPolicyProvider _abpAuthorizationPolicyProvider;
        private readonly IAbpAuthorizationService _abpAuthorizationService;

        public HostOnlyMethodInvocationAuthorizationService(
            ICurrentTenant currentTenant,
            IAbpAuthorizationPolicyProvider abpAuthorizationPolicyProvider,
            IAbpAuthorizationService abpAuthorizationService)
        {
            _currentTenant = currentTenant;
            _abpAuthorizationPolicyProvider = abpAuthorizationPolicyProvider;
            _abpAuthorizationService = abpAuthorizationService;
        }

        public async Task CheckAsync(MethodInvocationAuthorizationContext context)
        {
            if (AllowAnonymous(context))
            {
                return;
            }

            var authorizationPolicy = await AuthorizationPolicy.CombineAsync(
                _abpAuthorizationPolicyProvider,
                GetAuthorizationDataAttributes(context.Method)
            );

            if (authorizationPolicy == null)
            {
                return;
            }

            using (_currentTenant.Change(null))
                await _abpAuthorizationService.CheckAsync(authorizationPolicy);
        }

        protected virtual bool AllowAnonymous(MethodInvocationAuthorizationContext context)
        {
            return context.Method.GetCustomAttributes(true).OfType<IAllowAnonymous>().Any();
        }

        protected virtual IEnumerable<IAuthorizeData> GetAuthorizationDataAttributes(MethodInfo methodInfo)
        {
            var attributes = methodInfo
                .GetCustomAttributes(true)
                .OfType<IAuthorizeData>();

            if (methodInfo.IsPublic && methodInfo.DeclaringType != null)
            {
                attributes = attributes
                    .Union(
                        methodInfo.DeclaringType
                            .GetCustomAttributes(true)
                            .OfType<IAuthorizeData>()
                    );
            }

            return attributes;
        }
    }
}
