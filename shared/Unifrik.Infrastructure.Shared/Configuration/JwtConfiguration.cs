using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using Unifrik.Infrastructure.Shared.Configuration.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Logging;


namespace Unifrik.Infrastructure.Shared.Configuration
{
    public static class JwtConfiguration
    {
        public static IServiceCollection AddJwtConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = new JwtSettings();
            configuration.GetSection(nameof(JwtSettings)).Bind(jwtSettings);
            services.Configure<JwtSettings>(configuration.GetSection(nameof(JwtSettings)));

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(
        Convert.FromBase64String(jwtSettings.IssuerSigningKey ?? "")
    ),              ValidIssuer = jwtSettings.ValidIssuer,
                    ValidAudience = jwtSettings.ValidAudience,
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = true
                   
                };
                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        // Breakpoint here to see the raw token being received
                        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                        return Task.CompletedTask;
                    },
                    OnTokenValidated = context =>
                    {
                        // Breakpoint here to inspect the validated claims
                        var claims = context.Principal?.Claims.ToList();
                        return Task.CompletedTask;
                    },
                    OnAuthenticationFailed = context =>
                    {
                        
                        // Breakpoint here to debug authentication failures
                        var exception = context.Exception;
                        return Task.CompletedTask;
                    }
                };
            });
            return services;
        }
    }
}
