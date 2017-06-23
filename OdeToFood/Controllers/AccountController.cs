using Microsoft.AspNetCore.Mvc;
using OdeToFood.ViewModels;

namespace OdeToFood.Controllers
{
    public class AccountController : Controller
    {
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

            }
            return View();
        }
    }
}
