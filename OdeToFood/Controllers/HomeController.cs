using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using OdeToFood.Services;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IRestaurantData restaurantData)
        {

        }

        public IActionResult Index()
        {
            // Instantiate a new Restaurant object and add populate with data
            var model = new Restaurant { Id = 1, Name = "The House of Kobe" };

            return View(model);
        }
    }
}
