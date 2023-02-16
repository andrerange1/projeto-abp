using Bcx.Platform.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement;

namespace Bcx.Platform.Data
{
    public class SecurityDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
 
        private readonly IGuidGenerator _guidGenerator;
        private readonly ICurrentTenant _currentTenant;
        private readonly IdentityRoleManager _roleManager;
        private readonly IPermissionDefinitionManager _permissionDefinitionManager;
        private readonly IPermissionGrantRepository _permissionGrantRepository;
        private readonly ILogger<SecurityDataSeedContributor> _logger;

        public SecurityDataSeedContributor(
            IGuidGenerator guidGenerator,
            ICurrentTenant currentTenant,
            IdentityRoleManager roleManager,
            IPermissionDefinitionManager permissionDefinitionManager,
            IPermissionGrantRepository permissionGrantRepository,
            ILogger<SecurityDataSeedContributor> logger)
        {
            _guidGenerator = guidGenerator;
            _currentTenant = currentTenant;
            _roleManager = roleManager;
            _permissionDefinitionManager = permissionDefinitionManager;
            _permissionGrantRepository = permissionGrantRepository;
            _logger = logger;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            await EnsureVisitorRoleAsync();
            await EnsureDeveloperRoleAsync();
        }

        private async Task EnsureDeveloperRoleAsync()
        {
            var role = await GetOrCreateRoleAsync(RoleConsts.DeveloperRole);
            var forbidden = new List<string>()
            {
                "AbpIdentity.Roles.Create",
                "AbpIdentity.Roles.Update",
                "AbpIdentity.Roles.Delete",
                "AbpIdentity.Roles.ManagePermissions",

                "AbpIdentity.Users.Create",
                "AbpIdentity.Users.Update",
                "AbpIdentity.Users.Delete",
                "AbpIdentity.Users.ManagePermissions"
            };

            var permissions = _permissionDefinitionManager
                .GetPermissions()
                .Where(p => p.MultiTenancySide.HasFlag(_currentTenant.GetMultiTenancySide()))
                .Where(p => !forbidden.Contains(p.Name))
                .Select(x => x.Name)
                .ToList();

            await SyncPermissionsAsync(role, permissions);
        }

        private async Task EnsureVisitorRoleAsync()
        {
            var role = await GetOrCreateRoleAsync(RoleConsts.VisitorRoleName, isDefault: true);
            var grantedPermissions = new List<string>()
            {
                "AbpIdentity.Users",
                "AbpIdentity.Roles",
                "AbpIdentity.Users.ManagePermissions"
            };

            await SyncPermissionsAsync(role, grantedPermissions);
        }

        private async Task<IdentityRole> GetOrCreateRoleAsync(string roleName, bool isPublic = true, bool isStatic = true, bool isDefault = false)
        {
            var role = await _roleManager.FindByNameAsync(roleName);

            if (role == null)
            {
                role = new IdentityRole(_guidGenerator.Create(), roleName, _currentTenant.Id)
                {
                    IsPublic = isPublic,
                    IsStatic = isStatic,
                    IsDefault = isDefault
                };
                (await _roleManager.CreateAsync(role)).CheckErrors();
                _logger.LogInformation($"Role {role.Name} criada com sucesso!");
            }

            return role;
        }

        private async Task SyncPermissionsAsync(IdentityRole role, ICollection<string> grantedPermissions)
        {
            var currentPermissions = (await _permissionGrantRepository
                .GetListAsync(RolePermissionValueProvider.ProviderName,
                              role.Name))
                .Select(p => p.Name)
                .Intersect(grantedPermissions)
                .ToList();

            foreach (var permission in grantedPermissions)
            {
                if (currentPermissions.Find(x => x == permission) != null)
                {
                    continue;
                }

                await _permissionGrantRepository.InsertAsync(
                    new PermissionGrant(
                        _guidGenerator.Create(),
                        permission,
                        RolePermissionValueProvider.ProviderName,
                        role.Name,
                        _currentTenant.Id
                    )
                );
            }

            _logger.LogInformation($"Permissions from role {role.Name} has been syncronized successfully.");
        }
    }
}
