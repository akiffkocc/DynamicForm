using Microsoft.AspNetCore.Mvc;
using MvcProje.Models;
using System.Diagnostics;

namespace MvcProje.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var sessionUser = HttpContext.Session.GetString("username");
            if (sessionUser == null)
                return RedirectToAction("Login", "User");

            return View();
        }

        public IActionResult Privacy()
        {
            var sessionUser = HttpContext.Session.GetString("username");
            if (sessionUser == null)
                return RedirectToAction("Login", "User");

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var sessionUser = HttpContext.Session.GetString("username");
            if (sessionUser == null)
                return RedirectToAction("Login", "User");

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}