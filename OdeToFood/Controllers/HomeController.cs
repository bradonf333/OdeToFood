using Microsoft.AspNetCore.Mvc;
using OdeToFood.Services;
using OdeToFood.ViewModels;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;
        private IGreeter _greeter;

        /// <summary>
        /// Constructor that will assign the IRestaurantData and IGreeter to private variables
        /// </summary>
        /// <param name="restaurantData"></param>
        /// <param name="greeter"></param>
        public HomeController(IRestaurantData restaurantData, IGreeter greeter)
        {
            _restaurantData = restaurantData;
            _greeter = greeter;
        }

        /// <summary>
        /// Creates a model from the HomePageViewModel and assigns it the list of restaurants and the greeting string
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            // Instantiate a new Restaurant object and add populate with data
            var model = new HomePageViewModel();
            model.Restaurants = _restaurantData.GetAll();
            model.CurrentMessage = _greeter.GetGreeting();

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);
        }
    }
}
