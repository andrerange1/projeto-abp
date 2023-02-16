using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Volo.Abp.Security.Claims;

namespace Bcx.Platform.Security
{
    public static class PlatformIntegrationExtensions
    {
        public static string PlatformAuthenticationSection = "Authentication:Bearer";

        public static IServiceCollection AddPlatformAuthorization(this IServiceCollection services)
            => AddPlatformAuthorization(services, options
                => services.GetConfiguration()
                    .GetSection(PlatformAuthorizationOptions.PlatformAuthorizationSync).Bind(options));

        public static IServiceCollection AddPlatformAuthorization(this IServiceCollection services, Action<PlatformAuthorizationOptions> options = default)
        {
            // Configure Claims
            AbpClaimTypes.UserName = AzureAdClaimTypes.UserName;
            AbpClaimTypes.UserId = AzureAdClaimTypes.UserId;
            AbpClaimTypes.Role = AzureAdClaimTypes.Role;
            AbpClaimTypes.Email = AzureAdClaimTypes.Email;
            AbpClaimTypes.Name = AzureAdClaimTypes.Name;

            // Override options
            options = options ?? (_ => new PlatformAuthorizationOptions());
            services.Configure(options);

            return services;
        }

        /// <summary>
        /// Configura a Autenticação da aplicação segundo o protocolo da Plataforma Becomex.
        /// Utiliza como argumento a instância base do IConfiguration para automaticamente extrair os dados do appsettings.json ou environment variables.
        /// 
        /// <code>
        /// public void ConfigureServices(IServiceCollection services)
        /// {
        ///     services.AddPlatformAuthentication();
        /// }
        /// </code>
        /// 
        /// O Arquivo de configuração deve respeitar o modelo:
        /// <code>
        /// "Authentication": {
        ///     "Bearer": {
        ///           //Trata-se do Issuer do OpenID. Utilizar o OpenID Connect metadata document apenas até o "v2.0", desconsirando o .well-known/openid-configuration
        ///           "Authority": "https://login.microsoftonline.com/3b6b7936-fc74-4f59-83c3-d2d992988c0c/v2.0",
        ///           
        ///           //Quando utilizado o Azure AD, deve-se utilizar o ClientId
        ///           "Audience": "client_id"
        ///     }
        /// }
        /// </code>
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddPlatformAuthentication(this IServiceCollection services)
            => AddPlatformAuthentication(services, options => services
                .GetConfiguration()
                .GetSection(PlatformAuthenticationSection).Bind(options));

        /// <summary>
        /// Configura a Autenticação da aplicação segundo o protocolo da Plataforma Becomex.
        /// <br />
        /// <c>Authority</c> Trata-se do Issuer do OpenID. Utilizar o OpenID Connect metadata document apenas até o "v2.0", desconsirando o .well-known/openid-configuration
        /// <br />
        /// <c>Audience</c> Quando utilizado o Azure AD, deve-se utilizar o ClientId
        /// </summary>
        /// <param name="services"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static IServiceCollection AddPlatformAuthentication(this IServiceCollection services, Action<JwtBearerOptions> options = default)
        {
            services.Configure(options);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options);

            return services;
        }

        /// <summary>
        /// Adiciona o Middleware de Autorização na Plataforma Becomex.
        /// Além de sincronizar os usuários da plataforma, também elevará as permissões locais da aplicação para a sessão principal.
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UsePlatformAuthorization(this IApplicationBuilder app)
        {
            return app
                .UseMiddleware<PlatformAuthorizationMiddleware>()
                .UseAuthorization();
        }
    }
}
