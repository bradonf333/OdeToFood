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
        /// Lets the user Edit 1 restaurant by the restaurant id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _restaurantData.Get(id);

            // Handle null ids. Redirect to our index page
            if(model == null)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, RestaurantEditViewModel model)
        {
            // Instantiant a new restaurant object by finding a current restaurant
            // Finds the current restaurant by the given restaurant id
            var restaurant = _restaurantData.Get(id);

            // Check to make sure the model is valid
            if (ModelState.IsValid)
            {
                // Assign the new properties to the existing restaurant
                restaurant.Cuisine = model.Cuisine;
                restaurant.Name = model.Name;

                // Save the changes
                _restaurantData.Commit();

                // Return the user to the Details page passing in the Id so that they can see new changes.
                return RedirectToAction("Details", new { id = restaurant.Id });
            }
            return View(restaurant);
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
        [ValidateAntiForgeryToken]
        public IActionResult Create(RestaurantEditViewModel model)
        {
            // Make sure the Model is valid, if not then return back to the Create page
            if (ModelState.IsValid)
            {
                // Instantiate new restaurant that will hold the data from the EditViewModel
                var newRestaurant = new Restaurant();

                // Assign the properties
                newRestaurant.Cuisine = model.Cuisine;
                newRestaurant.Name = model.Name;

                // Add the new restaurant to our list of restaurants.
                newRestaurant = _restaurantData.Add(newRestaurant);

                // Commit the changes to the database (SaveChanges to the DbContext)
                _restaurantData.Commit();

                // Return the details of the new restaurant as a redirect
                return RedirectToAction("Details", new { id = newRestaurant.Id });
            }
            else
            {
                return View();
            }
        }
    }
}
