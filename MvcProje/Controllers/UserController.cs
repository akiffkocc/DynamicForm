using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using MvcProje.Models;

namespace MvcProje.Controllers
{
    public class UserController : Controller
    {
        UserService userService = new UserService(new EfUserDal());

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            var user = userService.Login(model.UserName, model.Password).GetAwaiter().GetResult();
            if (user != null)
            {
                HttpContext.Session.SetString("username", user.UserName);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Login", "User");
        }
    }
}
