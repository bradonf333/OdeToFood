using Microsoft.AspNetCore.Mvc;
using OdeToFood.Entities;
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

        /// <summary>
        /// Gives the details of 1 specific resaurant.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);

            // Handle null ids. Redirect to our index page
            if (model == null)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        /// <summary>
        /// Display a form to the user that will allow them to enter the data needed 
        /// to create a new restaurant. 
        /// This will be a Get request.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RestaurantEditViewModel model)
        {
            // Instantiate new restaurant that will hold the data from the EditViewModel
            var newRestaurant = new Restaurant();

            // Assign the properties
            newRestaurant.Cuisine = model.Cuisine;
            newRestaurant.Name = model.Name;

            // Add the new restaurant to our list of restaurants.
            newRestaurant = _restaurantData.Add(newRestaurant);

            // Return the details of the new restaurant as a redirect
            return RedirectToAction("Details", new { id = newRestaurant.Id });
        }
    }
}
