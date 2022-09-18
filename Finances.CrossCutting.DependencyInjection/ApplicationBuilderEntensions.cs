using KissLog;
using KissLog.AspNetCore;
using KissLog.CloudListeners.Auth;
using KissLog.CloudListeners.RequestLogsListener;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;


namespace Finances.CrossCutting.DependencyInjection
{
    public static class ApplicationBuilderEntensions
    {
        public static void UseCorsCustom(this IApplicationBuilder application)
        {
            application.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        }

        public static void UseExceptionCustom(this IApplicationBuilder application, IHostEnvironment environment)
        {
            //application.UseMiddleware<class>();
            if (environment.IsDevelopment())
            {
                application.UseDeveloperExceptionPage();
            }
            else
            {
                application.UseExceptionHandler("/Erro");
                application.UseStatusCodePagesWithReExecute("/Erro/{0}");
            }
        }

        public static void UserCookiePolicyCustom(this IApplicationBuilder application)
        {
            application.UseCookiePolicy();
        }

        public static void UseIdentityCustom(this IApplicationBuilder application)
        {
            application.UseAuthentication();
            application.UseAuthorization();
        }

        public static void UseHstsCustom(this IApplicationBuilder application, IHostEnvironment environment)
        {
            if (!environment.IsDevelopment())
            {
                application.UseHsts();
                application.UseHttpsRedirection();
            }
        }

        public static void UseEndPointCustom(this IApplicationBuilder application)
        {
            application.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }

        public static void UseEndPointCustom(this IApplicationBuilder application, string controller, string action)
        {
            application.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=" + controller + "}/{action=" + action + "}/{id?}");
            });
        }

        public static void UseWebAppCustom(this IApplicationBuilder application)
        {
            application.UseStaticFiles();
            application.UseRouting();
        }

        public static void UseKissLogMiddlewareCustom(this IApplicationBuilder application, IConfiguration configuration)
        {
            application.UseKissLogMiddleware(options => ConfigureKissLog(options, configuration));
        }

        public static void ConfigureKissLog(IOptionsBuilder options, IConfiguration configuration)
        {
            KissLogConfiguration.Listeners.Add(new RequestLogsApiListener(new Application(
                configuration["KissLog.OrganizationId"],
                configuration["KissLog.ApplicationId"])
            )
            {
                ApiUrl = configuration["KissLog.ApiUrl"]    //  "https://api.kisslog.net"
            });
        }

        //public static void UseSwaggerCustom(this IApplicationBuilder application)
        //{
        //    application.UseSwagger();
        //    application.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Loiu v1"));
        //}
    }
   
}
