﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood
{
    public interface IGreeter
    {
        string GetGreeting();
    }

    public class Greeter : IGreeter
    {
        public Greeter(IConfiguration configuration)
        {

        }
        public string GetGreeting()
        {
            return "Hello from the Greeter!";
        }
    }
}
