using Ilk_MVC_Proyekt.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ilk_MVC_Proyekt.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login(string username, string password)
        {
            var response = _userService.CheckUser(username, password);

            if (response == true)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("LoginOnError", "Belə hesab mövcud deyil !!!");
            return View("Index");
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult CreateUser(string username, string password, string confirmPassword)
        {
            if (password == confirmPassword)
            {
                _userService.CreateUser(username, password);
                return View("Index");
            }

            ModelState.AddModelError("RegisterOnError", "Parollar eyni deyil !!!");
            return View("Register");
        }
    }
}
