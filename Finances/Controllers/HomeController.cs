using Finances.CrossCutting.Helper;
using Finances.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Finances.Controllers
{
    [Authorize]
    public class HomeController : MainController
    {
        private readonly IUserServices _userServices;

        public HomeController(IUserServices userServices, ILogger<HomeController> logger) : base(logger)
        {
            _userServices = userServices;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var user = await _userServices.GetAllInf(HttpContext.Session.GetUsuario().Id);

            var notification = user.Debts.Any(x => x.DatePayment.Day == DateTime.Now.Day);

            if (notification)
            {
                var set = HttpContext.Session.GetUsuario();
                set.Notification = true;
                set.Debts = user.Debts.Where(x => x.DatePayment.Day == DateTime.Now.Day);                
                HttpContext.Session.Set(set);
            }

            return View(user);
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}