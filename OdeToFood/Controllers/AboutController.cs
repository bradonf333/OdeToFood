using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Controllers
{
    /// <summary>
    /// Controller used as an about page
    /// </summary>
    
    // Route tokens. Looks for the /controller/method url convention
    [Route("[controller]/[action]")]
    public class AboutController
    {
        public string Phone()
        {
            return "888-888-8888";
        }

        public string Address()
        {
            return "USA";
        }
    }
}
