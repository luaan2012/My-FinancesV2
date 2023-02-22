using AutoMapper;
using Finances.ModelView;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Finances.Models;
using Finances.Services.IServices;
using Finances.CrossCutting.Helper;

namespace Finances.Controllers
{
    public class AutenticationController : MainController
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IUserServices _userService;
        private readonly IMapper _mapper;

        public AutenticationController(IUserServices userServices, IMapper mapper, UserManager<IdentityUser> userManager, 
                                       SignInManager<IdentityUser> signInManager, ILogger<AutenticationController> logger) : base(logger) 
        {
            _userService = userServices;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }
        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost, Route("Register")]
        public async Task<IActionResult> Register(UserView user)
        {
            if (!ModelState.IsValid) return View(user);           

            var identity = new IdentityUser
            {
                Id = user.Id.ToString(),
                UserName = user.UserName,
                Email = user.Email,
                EmailConfirmed = true,
                PhoneNumber = user.Phone,
                PhoneNumberConfirmed = true
            };

            user.FirstLogin = true;
            user.RegisterHour = DateTime.Now;

            var result = await _userManager.CreateAsync(identity, user.Password);

            if (result.Succeeded)
            {

                if(user.ImageUpload is not null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{user.Id}");

                    FileHelper.SaveFiles(user.ImageUpload.OpenReadStream(), user.ImageUpload.FileName, path);

                    user.Imagem = user.ImageUpload.FileName;
                }
                
                await _userService.CreateUser(identity, _mapper.Map<Users>(user));

                ViewBag.Success = true;
            }

            TempData["error"] = result?.Errors;

            return View(user);
        }

        [HttpPost, Route("Login")]
        public async Task<IActionResult> Login(UserView user)
        {

            var result = await _signInManager.PasswordSignInAsync(user.UserName, user.Password, false, true);
           
            if (result.Succeeded)
            {
                var setUser = await _userService.FindUserByUserName(user.UserName);
                HttpContext.Session.Set(setUser);
                return RedirectToAction("Index", "Home");
            }

            if (result.IsLockedOut)
            {
                ViewBag.Error = true;
                return View();
            }

            ViewBag.Error = true;

            return View(user);
        }

        public IActionResult ForgetPassword()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("Login");
        }

        private async Task<bool> UploadFile (IFormFile file, Guid pathUser)
        {
            if ((file?.Length ?? 0) <= 0) return false;

            var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{pathUser}", file.FileName);

            if(System.IO.File.Exists(path))
            {
                ModelState.AddModelError(string.Empty, "Já existe um arquivo com esse nome!");
                return false;
            }

            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            using (var stream = System.IO.File.Create(path))
            {
                await file.CopyToAsync(stream);
            }

            return true;
        }
    }
}
