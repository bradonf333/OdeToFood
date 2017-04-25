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
    
    [Route("[controller]")]
    public class AboutController
    {
        [Route("phone")]
        public string Phone()
        {
            return "888-888-8888";
        }

        [Route("address")]
        public string Address()
        {
            return "USA";
        }
    }
}
