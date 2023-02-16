using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.Security.Claims;
using Volo.Abp.Users;

namespace Bcx.Platform.Security
{

    public class PlatformAuthorizationMiddleware : IMiddleware, ITransientDependency
    {
        private readonly ILogger<PlatformAuthorizationMiddleware> _logger;
        private readonly ISecurityAppService _securityAppService;
        private readonly ICurrentUser _currentUser;
        private readonly ICurrentPrincipalAccessor _currentPrincipalAcessor;
        private readonly IOptions<PlatformAuthorizationOptions> _options;
        private readonly IOptions<JwtBearerOptions> _jwtOptions;

        public PlatformAuthorizationMiddleware(
            ILogger<PlatformAuthorizationMiddleware> logger,
            ISecurityAppService securityAppService,
            ICurrentUser currentUser,
            ICurrentPrincipalAccessor currentPrincipalAccessor,
            IOptions<PlatformAuthorizationOptions> options,
            IOptions<JwtBearerOptions> jwtOptions)
        {
            _logger = logger;
            _securityAppService = securityAppService;
            _currentUser = currentUser;
            _currentPrincipalAcessor = currentPrincipalAccessor;
            _options = options;
            _jwtOptions = jwtOptions;
        }

        [AllowAnonymous]
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (_currentUser.IsAuthenticated)
            {
                try
                {
                    var localUser = await GetUserAsync();

                    if (localUser == null)
                    {
                        throw new UserSyncronizationException();
                    }

                    if (CheckLastUpdateTime(_currentPrincipalAcessor.Principal, localUser.User))
                    {
                        await _securityAppService.TryUpdateUserDataAsync(new CreateUpdateLocalUserDto
                        {
                            User = localUser.User,
                        });
                    }

                    _currentPrincipalAcessor.Principal.AddIdentity(localUser.Claims);
                    _logger.LogInformation($"Platform User is fully Authenticated");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    await context.ForbidAsync();
                    return;
                }
            }

            await next(context);
        }

        private Task<SyncUserResultDto> GetUserAsync()
        {
            return IsAppCredentials(_currentPrincipalAcessor.Principal)
                ? GetAppUserAsync()
                : GetPlatformUserAsync();
        }

        private Task<SyncUserResultDto> GetPlatformUserAsync()
        {
            var tokenUser = _options.Value.JwtClaimsToIdentityUserMapper(_currentPrincipalAcessor.Principal);
            return _securityAppService.GetOrCreateLocalUserAsync(new CreateUpdateLocalUserDto
            {
                User = tokenUser
            });
        }

        private Task<SyncUserResultDto> GetAppUserAsync()
        {
            return _securityAppService.GetOrCreateLocalUserAsync(new CreateUpdateLocalUserDto
            {
                User = new IdentityUserDto
                {
                    Email = _options.Value.ApplicationUserEmail
                }
            });
        }

        private bool IsAppCredentials(ClaimsPrincipal principal)
        {
            var oid = principal.Oid();
            var sub = principal.Sub();
            var azp = principal.Azp();

            return oid == sub && azp == _jwtOptions.Value.Audience;
        }

        private bool CheckLastUpdateTime(ClaimsPrincipal claims, IdentityUserDto user)
        {
            var issuedAtStr = claims.FindFirstValue(JwtClaimTypes.IssuedAt);

            if (string.IsNullOrEmpty(issuedAtStr))
            {
                return true;
            }

            var issuedAt = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(int.Parse(issuedAtStr));
            return user?.LastModificationTime?.ToUniversalTime() < issuedAt;
        }
    }
}
