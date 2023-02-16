using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;

namespace Bcx.Platform.Security
{
    public static class PlatformSwaggerExtensions
    {
        public static IApplicationBuilder UsePlatformSwagger(this IApplicationBuilder app,
                                                             Action<PlatformSwaggerOptions> swaggerOptions = default,
                                                             Action<JwtBearerOptions> jwtOptions = default)
        {
            var swaggerSettings = app.ApplicationServices.GetService<IOptions<PlatformSwaggerOptions>>();
            var jwtSettings = app.ApplicationServices.GetService<IOptions<JwtBearerOptions>>();

            swaggerOptions?.Invoke(swaggerSettings.Value);
            jwtOptions?.Invoke(jwtSettings.Value);

            app.UseSwagger();
            app.UseAbpSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", swaggerSettings.Value.ApiName);
                options.OAuthClientId(jwtSettings.Value.Audience);
                options.OAuthUsePkce();
            });

            return app;
        }

        public static IServiceCollection AddPlatformSwagger(this IServiceCollection services)
            => AddPlatformSwagger(services, options
                => services.GetConfiguration().GetSection(PlatformSwaggerOptions.PlatformSwaggerSection).Bind(options));

        public static IServiceCollection AddPlatformSwagger(this IServiceCollection services, Action<PlatformSwaggerOptions> options = default)
        {
            var settings = new PlatformSwaggerOptions();

            services.GetConfiguration()
                .GetSection(PlatformSwaggerOptions.PlatformSwaggerSection)
                .Bind(settings);

            options ??= (_ => new PlatformSwaggerOptions());
            services.Configure(options);

            options?.Invoke(settings);

            return services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo { Title = settings.ApiName, Version = "v1" });
                opt.DocInclusionPredicate((docName, description) => true);
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows()
                    {
                        AuthorizationCode = new OpenApiOAuthFlow()
                        {
                            Scopes = new Dictionary<string, string>
                            {
                                { "openid", "OpenId" },
                                { "profile", "Profile" },
                                { "email", "email" },
                                { "offline_access", "offline_access" },
                                { $"{settings.ApiName}/{settings.Scope}", $"{settings.ApiName}/{settings.Scope}" }
                            },
                            TokenUrl = new Uri(settings.TokenUrl),
                            AuthorizationUrl = new Uri(settings.AuthorizationUrl)
                        }
                    }
                });

                opt.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme()
                        {
                            Reference = new OpenApiReference()
                            {
                                Id = "Bearer", //The name of the previously defined security scheme.
                                Type = ReferenceType.SecurityScheme
                            }
                        },
                        new List<string>()
                        {
                            "openid",
                            "profile",
                            "email",
                            "offline_access",
                            $"{settings.ApiName}/{settings.Scope}"
                        }
                    }
                });
            });
        }
    }
}
