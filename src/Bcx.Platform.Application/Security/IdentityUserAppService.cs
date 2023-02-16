using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.Validation;

namespace Bcx.Platform.Security
{
    [Dependency(ReplaceServices = true)]
    [RemoteService(IsEnabled = false)]
    [ExposeServices(typeof(IIdentityUserAppService), typeof(Volo.Abp.Identity.IdentityUserAppService), typeof(IdentityUserAppService))]
    public class IdentityUserAppService : Volo.Abp.Identity.IdentityUserAppService
    {
        public IdentityUserAppService(
            IdentityUserManager userManager,
            IIdentityUserRepository userRepository,
            IIdentityRoleRepository roleRepository,
            IOptions<IdentityOptions> identityOptions)
            : base(userManager, userRepository, roleRepository, identityOptions)
        {
        }

        public async override Task<IdentityUserDto> CreateAsync(IdentityUserCreateDto input)
        {
            ValidateUserRoles(input);
            return await base.CreateAsync(input);
        }

        public async override Task<IdentityUserDto> UpdateAsync(Guid id, IdentityUserUpdateDto input)
        {
            ValidateUserRoles(input);
            return await base.UpdateAsync(id, input);
        }

        private void ValidateUserRoles(IdentityUserCreateOrUpdateDtoBase input)
        {
            if (input.RoleNames.IsNullOrEmpty())
            {
                throw new AbpValidationException(
                    "É obrigatório informar os papéis do usuário!",
                    new List<ValidationResult>
                    {
                        new ValidationResult("Os papéis do usuário não foram informados!", new []{"RoleNames"})
                    }
                );
            }
        }
    }
}
