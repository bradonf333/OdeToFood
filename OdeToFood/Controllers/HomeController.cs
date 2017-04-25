using Microsoft.AspNetCore.Mvc;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Hello, from the HomeController";
        }
    }
}
