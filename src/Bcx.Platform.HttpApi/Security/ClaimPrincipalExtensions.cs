using System;
using System.Linq;
using System.Security.Claims;
using Volo.Abp.Identity;

namespace Bcx.Platform.Security
{
    public static class ClaimPrincipalExtensions
    {
        internal static string Oid(this ClaimsPrincipal principal) => principal.FindFirstValue(AzureClaims.Oid);
        internal static string Sub(this ClaimsPrincipal principal) => principal.FindFirstValue(AzureClaims.Sub);
        internal static string Azp(this ClaimsPrincipal principal) => principal.FindFirstValue(AzureClaims.Azp);

        public static IdentityUserDto ToIdentityUser(this ClaimsPrincipal principal)
        {
            var userOrPhoneOrEmail = principal.FindFirstValue(AzureAdClaimTypes.UserName) ?? "";
            var fullName = principal.FindFirstValue(AzureAdClaimTypes.Name) ?? "";

            var splitedName = fullName.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var name = splitedName.FirstOrDefault();
            var surname = string.Join(" ", splitedName.Skip(1));

            return new IdentityUserDto()
            {
                Id = new Guid(principal.FindFirstValue(AzureAdClaimTypes.UserId)),
                Email = principal.FindFirstValue(AzureAdClaimTypes.Email),
                EmailConfirmed = true,
                UserName = userOrPhoneOrEmail
                    .Split('@')
                    .FirstOrDefault(),
                Name = name,
                Surname = surname
            };
        }

        public static class AzureClaims
        {
            public const string Oid = "http://schemas.microsoft.com/identity/claims/objectidentifier";
            public const string Sub = "sub";
            public const string Azp = "azp";
        }
    }
}
