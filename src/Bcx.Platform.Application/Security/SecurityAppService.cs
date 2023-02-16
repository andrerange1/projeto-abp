using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Volo.Abp.Identity;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Security.Claims;
using Volo.Abp.Uow;

namespace Bcx.Platform.Security
{
    [RemoteService(false)]
    [AllowAnonymous]
    public class SecurityAppService : ApplicationService, ISecurityAppService, ITransientDependency
    {
        private readonly IdentityUserManager _identityUserManager;
        private readonly ILogger<SecurityAppService> _logger;
        private readonly IObjectMapper _objectMapper;
        private readonly IdentityRoleManager _roleManager;
        private readonly IGuidGenerator _guidGenerator;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        private static string BecomexProvider = "becomex";

        public SecurityAppService(IdentityUserManager identityUserManager,
                                  ILogger<SecurityAppService> logger,
                                  IObjectMapper objectMapper,
                                  IdentityRoleManager roleManager,
                                  IGuidGenerator guidGenerator,
                                  IUnitOfWorkManager unitOfWorkManager)
        {
            _identityUserManager = identityUserManager;
            _logger = logger;
            _objectMapper = objectMapper;
            _roleManager = roleManager;
            _guidGenerator = guidGenerator;
            _unitOfWorkManager = unitOfWorkManager;
        }

        [UnitOfWork]
        public async Task<SyncUserResultDto> GetOrCreateLocalUserAsync(CreateUpdateLocalUserDto input)
        {
            _logger.LogTrace("Searching user by email strategy");
            var user = await _identityUserManager.FindByLoginAsync(BecomexProvider, input.User.Email.ToUpper());

            if (user == null)
            {
                user = await CreateUserAsync(input.User);
            }

            return new SyncUserResultDto
            {
                User = _objectMapper.Map<IdentityUser, IdentityUserDto>(user),
                Claims = await GetLocalClaimsAsync(user)
            };
        }

        private async Task<IdentityUser> CreateUserAsync(IdentityUserDto input)
        {
            
            if (input.Id == Guid.Empty)
            {
                input.Id = _guidGenerator.Create();
            }

            var user = _objectMapper.Map<IdentityUserDto, IdentityUser>(input);
            user.IsExternal = true;

            using (var uow = _unitOfWorkManager.Begin(isTransactional: true))
            {
                (await _identityUserManager.CreateAsync(user)).CheckErrors();
                (await _identityUserManager.AddDefaultRolesAsync(user)).CheckErrors();
                (await _identityUserManager.AddLoginAsync(
                    user,
                    new UserLoginInfo(
                        BecomexProvider,
                        input.Email.ToUpper(),
                        $"Becomex AD ${input.Email}"
                    )
                )).CheckErrors();

                await uow.SaveChangesAsync();
            }

            _logger.LogTrace($"Criado usuário local para a identificação {user.Id}");

            return user;
            
        }

        [UnitOfWork]
        public async Task<bool> TryUpdateUserDataAsync(CreateUpdateLocalUserDto input)
        {
            try
            {
                var user = await _identityUserManager.GetByIdAsync(input.User.Id);
                _objectMapper.Map(input.User, user);
                await _identityUserManager.UpdateAsync(user);
                _logger.LogInformation($"User {user.Name} has updated local data.");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Fail on update user's local data", ex.Message);
            }
            return false;
        }


        private async Task<ClaimsIdentity> GetLocalClaimsAsync(IdentityUser user)
        {
            var claims = await _identityUserManager.GetClaimsAsync(user);
            await AddRoleToClaims(claims, user);
            return new ClaimsIdentity(claims);
        }

        private async Task AddRoleToClaims(IList<Claim> claims, IdentityUser user)
        {
            try
            {
                var roles = await _identityUserManager.GetRolesAsync(user);

                foreach (var role in roles)
                    claims.Add(new Claim(AbpClaimTypes.Role, role));

                _logger.LogTrace($"Local roles was loaded to {user.Name}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

    }
}
