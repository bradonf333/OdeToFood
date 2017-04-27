using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using OdeToFood.Services;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;

        /// <summary>
        /// Constructor that will assign the IRestaurantData to a private variable
        /// </summary>
        /// <param name="restaurantData"></param>
        public HomeController(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        public IActionResult Index()
        {
            // Instantiate a new Restaurant object and add populate with data
            var model = new Restaurant { Id = 1, Name = "The House of Kobe" };

            return View(model);
        }
    }
}
