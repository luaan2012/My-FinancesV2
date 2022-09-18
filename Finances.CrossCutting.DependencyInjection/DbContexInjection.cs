using Finances.CrossCutting.Helper;
using Finances.Domain.IRepository;
using Finances.Domain.Repository;
using Finances.Services.IServices;
using Finances.Services.Services;
using Microsoft.Extensions.DependencyInjection;



namespace Finances.CrossCutting.DependencyInjection
{
    public static class DbContexInjection
    {
        public static void AddDbContexInjectionCustom(this IServiceCollection services)
        {
            #region Services
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IGeralService, GeralService>();
            services.AddScoped<AudFilter>();

            #endregion

            #region Repository
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IGeralRepository, GeralRepository>();
            #endregion
        }
    }
}
