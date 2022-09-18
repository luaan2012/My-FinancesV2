using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http.Extensions;


namespace Finances.CrossCutting.Helper
{
    public class AudFilter : IActionFilter
    {
        private readonly ILogger<AudFilter> _logger;

        public AudFilter(ILogger<AudFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if(context.HttpContext.Session.isLogado())
            {
                var message = context.HttpContext.Session.GetUsuario().Name + "Acessou: " +
                              context.HttpContext.Request.GetDisplayUrl();

                _logger.LogInformation(message);
            }
        }

        public void OnActionExecuting(ActionExecutingContext context){}
    }
}
