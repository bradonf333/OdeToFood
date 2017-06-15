using Microsoft.AspNetCore.Mvc;
using OdeToFood.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.ViewComponents
{
    /// <summary>
    /// ViewComponent that builds a greeting model and passes it back as a View.
    /// This can be shared across multiple Views since this builds the greeter model
    /// and then just passes it back as a view.
    /// </summary>
    public class GreetingViewComponent : ViewComponent
    {
        private IGreeter _greeter;

        public GreetingViewComponent(IGreeter greeter)
        {
            _greeter = greeter;
        }

        public IViewComponentResult Invoke()
        {
            var model = _greeter.GetGreeting();
            return View("Default", model);
        }
    }
}
