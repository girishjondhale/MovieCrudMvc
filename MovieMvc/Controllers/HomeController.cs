using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieMvc.Models;
using System.Diagnostics;

namespace MovieMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<string> cities = new List<string>() {"pune","nashik","mumbai" };
            ViewData["cities"] = new SelectList(cities);
            ViewData["list"] = new MultiSelectList(cities);
            return View();
        }
        public IActionResult Index(IFormCollection form, ICollection<string> hobbies)
        {
            ViewBag.Username = form["username"];
            ViewBag.Gender = form["gender"];
            ViewBag.City = form["cities"];
            ViewBag.Hobbies =form[ "hobbies"];
            ViewBag.Comments =form["comments"];

            return View("ShowInfo");

            return View();
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}