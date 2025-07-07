using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Unifrik.Infrastructure.Shared.User;


namespace Unifrik.Infrastructure.Shared.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSharedServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks();
            services.AddSwaggerRequirement();
            services.AddJwtConfiguration(configuration);
            services.AddScoped<ICurrentUser, CurrentUser>();
           
            return services;
        }
    }
}
