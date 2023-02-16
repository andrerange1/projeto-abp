using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Volo.Abp.AspNetCore.ExceptionHandling;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.AntiForgery;

namespace Bcx.Platform.Platform
{
    public static class PlatformDefaultConfigurationExtensions
    {
        /// <summary>
        /// Desabilita trava de Anti-Forgery nas requisições de POST, PUT, PATCH e DELETE.
        /// 
        /// O cenário arquitetural da Becomex permite que múltiplis clientes façam requisições nas nossas APIs.
        /// Inclusive clientes de outras linhas fiscais.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddDisableAbpAntiForgery(this IServiceCollection services)
            => services.Configure<AbpAntiForgeryOptions>(options =>
            {
                options.AutoValidate = false;
            });

        /// <summary>
        /// Habilita o envio de descrições dos erros de validação e erros de excesução de rotinas para as aplicações Clientes.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddApiExceptions(this IServiceCollection services)
            => services.Configure<AbpExceptionHandlingOptions>(options =>
            {
                options.SendExceptionsDetailsToClients = true;
            });

        /// <summary>
        /// Adiciona uma política padrão de CORS compatível com a Plataforma Becomex
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddPlatformCorsConfiguration(this IServiceCollection services)
            => AddPlatformCorsConfiguration(services, options
                => services.GetConfiguration().GetSection(PlatformCorsOptions.PlatformCorsSection).Bind(options));

        /// <summary>
        /// <inheritdoc cref="AddPlatformCorsConfiguration"/>
        /// </summary>
        /// <param name="services"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static IServiceCollection AddPlatformCorsConfiguration(this IServiceCollection services, Action<PlatformCorsOptions> options = default)
        {
            var corsSettings = new PlatformCorsOptions();
            options?.Invoke(corsSettings);

            return services.AddCors(opt =>
            {
                opt.AddPolicy(corsSettings.CorsPolicyName, builder =>
                    builder
                       .AllowAnyHeader()
                       .AllowAnyMethod()
                       .AllowCredentials()
                       .SetIsOriginAllowed(origin => corsSettings.GetAllowedDomains().Any(host => new Uri(origin).Host.EndsWith(host))));
            });
        }

        /// <summary>
        /// Cria controllers dinâmicos para serviços usando as boas práticas de REST.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="module"></param>
        /// <returns></returns>
        public static IServiceCollection AddPlatformConventionalControllers(this IServiceCollection services, Type module)
            => services.Configure<AbpAspNetCoreMvcOptions>(options =>
                {
                    options.ConventionalControllers.Create(module.Assembly, opts =>
                    {
                        opts.UrlControllerNameNormalizer = p => $"{p.ControllerName.ToKebabCase()}";
                        opts.UrlActionNameNormalizer = p => $"{p.ActionNameInUrl.ToKebabCase()}";
                    });
                });
    }
}
