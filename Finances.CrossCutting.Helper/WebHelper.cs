using Finances.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.CrossCutting.Helper
{
    public static class WebHelper
    {
        public static bool isOrigemApp(HttpContext context)
        {
            var isOrigemApp = bool.Parse(context?.User?.Claims?.FirstOrDefault(c => c.Type == TipoClaim.OrigemMobile)?.Value ?? "false");
            return isOrigemApp;
        }

        public static bool isMobile(HttpContext context)
        {
            var keysMobile = new string[] { "mobile", "midp", "tablet", "phone", "ipad", "android" };
            var userAgente = context.Request.Headers.FirstOrDefault(x => x.Key.ToLower() == "user-agent").Value.ToString().ToLower();
            var isMobile = keysMobile.Any(x => userAgente.Contains(x));
            return isMobile;
        }

        public static bool isWebView(HttpContext context)
        {
            var isDeepLink = bool.Parse(context?.User?.Claims?.FirstOrDefault(c => c.Type == TipoClaim.WebView)?.Value ?? "false");
            return isDeepLink;
        }

        public static bool isDesktop(HttpContext context)
        {
            var keysMobile = new string[] { "windows", "macintosh", "macos" };
            var userAgente = context.Request.Headers.FirstOrDefault(x => x.Key.ToLower() == "user-agent").Value.ToString().ToLower();
            var isDesktop = keysMobile.Any(x => userAgente.Contains(x));

            var platform = context.Request.Headers.FirstOrDefault(x => x.Key.ToLower() == "sec-ch-ua-platform").Value.ToString().ToLower();
            var isDesktopConfirm = keysMobile.Any(x => userAgente.Contains(x));

            return isDesktop && isDesktopConfirm;
        }

        public static bool isIphone(HttpContext context)
        {
            var keysApple = new string[] { "mac", "iphone" };
            var userAgente = context.Request.Headers.FirstOrDefault(x => x.Key.ToLower() == "user-agent").Value.ToString().ToLower();
            var device = keysApple.Any(x => userAgente.Contains(x));
            return device;
        }

        public static bool isAndroid(HttpContext context)
        {
            var keysApple = new string[] { "android" };
            var userAgente = context.Request.Headers.FirstOrDefault(x => x.Key.ToLower() == "user-agent").Value.ToString().ToLower();
            var device = keysApple.Any(x => userAgente.Contains(x));
            return device;
        }

        public static bool isDomainMobile(HttpContext context)
        {
            var host = context.Request.Host.Host.ToLower();
            var isDomainMobile = host.Contains("mob");
            return isDomainMobile;
        }

        public static string mustValidateLink(this HttpContext context, string link, IConfiguration _configuration)
        {
            return link;

            if (string.IsNullOrEmpty(link))
                return string.Empty;

            var deepLink = isIphone(context) ? _configuration["AppsMobile:IOS:DeepLink"] : _configuration["AppsMobile:Android:DeepLink"];
            var newLink = deepLink + "?{\"PaginacaoDeepLink\": {\"UsuarioId\":1,\"WebView\":true,\"LinkPagina\":\"" + link + "\"}}";

            //O Usuário está no Browser do Mobile vindo do APP
            if (isOrigemApp(context) && !isWebView(context) && isMobile(context))
                return newLink;
            //O Usuário está no WebView pelo APP
            else if (isOrigemApp(context) && isWebView(context) && isMobile(context))
                return link;
            //O Usuário está no Browser do Mobile e não veio pelo APP
            else if (isMobile(context) && !isOrigemApp(context))
                return link;
            else
                return link;
        }

        public static string mustRedirect(HttpContext context)
        {
            var self = "_self";
            var blank = "_blank";
            return blank;
            //WebView Mobile
            if (isMobile(context) && isWebView(context))
                return self;
            //Browser Mobile
            else if (isMobile(context) && !isWebView(context))
                return blank;
            //Browser Desktop
            else if (isDesktop(context))
                return blank;
            else
                return blank;
        }
    }
}
