using Microsoft.AspNetCore.Mvc;

namespace Finances.Controllers
{
    public abstract class MainController : Controller
    {
        private readonly ILogger<MainController> _logger;
        public MainController(ILogger<MainController> logger)
        {
            _logger = logger;
        }
    }
}
