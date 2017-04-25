using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Instantiate a new Restaurant object and add populate with data
            var model = new Restaurant { Id = 1, Name = "The House of Kobe" };

            return Content("Hello, from the HomeController");
        }
    }
}
