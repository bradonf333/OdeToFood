using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Entities;
using OdeToFood.ViewModels;
using System.Threading.Tasks;

namespace OdeToFood.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<User> _signInManager;
        private UserManager<User> _userManager;

        /// <summary>
        /// Constructor to bring in Identity Framework services needed for handeling users
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="signInManager"></param>
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        /// Get request to show the RegisterUser View for registering new users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Instantiate a User property and assign the Username
                var user = new User { UserName = model.Username };

                // Create the user on the database, passing in our User object from above,
                // and passing the Password from the model directly to the database.
                // Store in a variable called createResult.
                var createResult = await _userManager.CreateAsync(user, model.Password);

                // Make sure that the user is successfully created,
                // if so sign them in and redirect to the Home controller.
                // If false, add the error to the ModelState so they will show on the
                // RegisterView
                if(createResult.Succeeded)
                {
                    // .. Sign in the User
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in createResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View();
        }
    }
}
