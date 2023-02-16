using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.TenantManagement;

namespace Bcx.Platform.UserTenants
{
    [Controller]
    // [RemoteService(Name = TenantManagementRemoteServiceConsts.RemoteServiceName)]
    [Area("identity")]
    [ControllerName("User")]
    [Route("/api/identity/users/{userId:guid}/tenants")]
    public class UserTenantsController : AbpController
    {

        private readonly IUserTenantAppService _userTenantAppService;

        public UserTenantsController(IUserTenantAppService userTenantAppService)
        {
            _userTenantAppService = userTenantAppService;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResultDto<UserTenantDto>>> GetAllAsync(Guid userId, UserTenantsGetAllInput input)
        {
            var filters = ObjectMapper.Map<UserTenantsGetAllInput, GetAllUserTenantDto>(input);
            filters.UserId = userId;

            return Ok(await _userTenantAppService.GetListAsync(filters));
        }

        [HttpPost]
        public async Task<ActionResult<UserTenantDto>> CreateAsync(Guid userId, EntityDto<Guid> input)
        {
            var tenant = await _userTenantAppService
                .CreateAsync(new CreateUpdateUserTenantDto { TenantId = input.Id, UserId = userId });

            return CreatedAtAction(nameof(GetByIdAsync), new { tenantId = tenant.TenantId }, tenant);
        }

        [HttpGet]
        [Route("{tenantId:guid}")]
        public async Task<ActionResult<TenantDto>> GetByIdAsync(Guid userId, Guid tenantId)
        {
            var tenant = await _userTenantAppService
                .GetAsync(new UserTenantKeys { TenantId = tenantId, UserId = userId });

            return Ok(tenant);
        }

        [HttpDelete]
        [Route("{tenantId:guid}")]
        public async Task<ActionResult> DeleteAsync(Guid userId, Guid tenantId)
        {
            await _userTenantAppService
                .DeleteAsync(new UserTenantKeys { TenantId = tenantId, UserId = userId });

            return Ok();
        }
    }
}
