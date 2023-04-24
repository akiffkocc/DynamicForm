using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MvcProje.Controllers
{
    public class UserController : Controller
    {
        UserService userService = new UserService(new EfUserDal());
        public IActionResult Login()
        {
            return View();
        }
    }
}
