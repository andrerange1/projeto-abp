using Bcx.Platform.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Bcx.Platform.UserTenants
{
    [RemoteService(IsEnabled = false)]
    [Authorize]
    public class UserTenantAppService : AbstractKeyCrudAppService<UserTenant, UserTenantDto, UserTenantKeys, GetAllUserTenantDto, CreateUpdateUserTenantDto>, IUserTenantAppService
    {
        protected override string CreatePolicyName { get; set; } = SecurityPermissions.UserTenants.Criar;
        protected override string UpdatePolicyName { get; set; } = SecurityPermissions.UserTenants.Alterar;
        protected override string DeletePolicyName { get; set; } = SecurityPermissions.UserTenants.Remover;

        public UserTenantAppService(IRepository<UserTenant> repository) : base(repository)
        {
        }

        protected override Task DeleteByIdAsync(UserTenantKeys id)
        {
            return Repository.DeleteAsync(
                q => q.UserId == id.UserId && q.TenantId == id.TenantId,
                autoSave: true);
        }

        protected override Task<UserTenant> GetEntityByIdAsync(UserTenantKeys id)
        {
            return Task.FromResult(Repository
                .Where(q => q.UserId == id.UserId && q.TenantId == id.TenantId)
                .FirstOrDefault());
        }

        [Obsolete]
        protected override IQueryable<UserTenant> CreateFilteredQuery(GetAllUserTenantDto input)
        {
            return Repository
                .WithDetails(q => q.Tenant, q => q.User)

                //public string SearchByTenant { get; set; }
                .WhereIf(!string.IsNullOrWhiteSpace(input.SearchByTenant),
                    q => q.Tenant.Name.ToLowerInvariant().Contains(input.SearchByTenant.Trim().ToLowerInvariant()))

                //public string SearchByUser { get; set; }
                .WhereIf(!string.IsNullOrWhiteSpace(input.SearchByUser),
                    q => q.User.Name.ToLowerInvariant().Contains(input.SearchByUser.Trim().ToLowerInvariant()))

                //public Guid UserId { get; set; }
                .WhereIf(input.UserId.HasValue,
                    q => q.UserId == input.UserId)

                //public Guid TenantId { get; set; }
                .WhereIf(input.TenantId.HasValue,
                    q => q.TenantId == input.TenantId)

                //public IEnumerable<Guid> TenantIds { get; set; }
                .WhereIf(input.TenantIds.Any(),
                    q => input.TenantIds.Any(x => x == q.TenantId));
        }
    }
}
