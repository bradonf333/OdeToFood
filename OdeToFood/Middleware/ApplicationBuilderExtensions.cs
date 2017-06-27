﻿using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Middleware
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseNodeModules(this IApplicationBuilder app)
        {
            // Create an options object to hold any options needed for StaticFiles using node_modules folder
            var options = new StaticFileOptions();

            // Ignore any requests if they don't beging with /node_modules
            options.RequestPath = "/node_modules";


            app.UseStaticFiles();
            return app;
        }
    }
}
