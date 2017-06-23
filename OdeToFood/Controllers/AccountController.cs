using Microsoft.AspNetCore.Mvc;
using OdeToFood.ViewModels;

namespace OdeToFood.Controllers
{
    public class AccountController : Controller
    {
        // Constructor to bring in Identity Framework services
        public AccountController()
        {

        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Register(RegisterUserViewModel model)
        {
            if(ModelState.IsValid)
            {
                // ... Create a user
            }
            return View();
        }
    }
}
