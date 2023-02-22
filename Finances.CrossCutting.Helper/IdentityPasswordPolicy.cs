using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Finances.CrossCutting.Helper
{
    public static class IdentityPasswordPolicy
    {
        public static IServiceCollection AddPasswordConfiguration(this IServiceCollection services)
        {
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;        
            });

            return services;
        }
    }
}
