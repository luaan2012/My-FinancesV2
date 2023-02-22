using Finances.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using KissLog;
using KissLog.AspNetCore;
using KissLog.Formatters;
using Finances.CrossCutting.Helper;

namespace Finances.CrossCutting.DependencyInjection
{
    public static class ServiceExtensionsInjection
    {
        public static void AddServiceDbInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite("DataSource=teste.db"));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddErrorDescriber<IdentityMessagePortuguese>();

            services.AddPasswordConfiguration();

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //builder.Services.AddDatabaseDeveloperPageExceptionFilter();
        }

        public static void AddSecurityCustom(this IServiceCollection services)
        {
            services.AddCors();
        }

        public static void UseGlobalizationCustom(this IApplicationBuilder app)
        {
            var culture = CultureInfo.CreateSpecificCulture("pt-BR");
            var dateformat = new DateTimeFormatInfo
            {
                ShortDatePattern = "dd/MM/yyyy",
                LongDatePattern = "dd/MM/yyyy hh:mm:ss tt"
            };
            culture.DateTimeFormat = dateformat;

            var supportedCultures = new[]
            {
                culture
            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(culture),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

        }

        public static void KissLoggingCustom(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            services.AddScoped<IKLogger>((provider) => Logger.Factory.Get());

            services.AddLogging(logging =>
            {
                logging.AddKissLog(options =>
                {
                    options.Formatter = (FormatterArgs args) =>
                    {
                        if (args.Exception == null)
                            return args.DefaultValue;

                        string exceptionStr = new ExceptionFormatter().Format(args.Exception, args.Logger);

                        return string.Join(Environment.NewLine, new[] { args.DefaultValue, exceptionStr });
                    };
                });
            });
        }
    }
}
