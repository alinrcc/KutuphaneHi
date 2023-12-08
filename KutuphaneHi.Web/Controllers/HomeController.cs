using KutuphaneHi.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KutuphaneHi.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(ApplicationDbContext context)
        {
            //var result = context.Books.First();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}