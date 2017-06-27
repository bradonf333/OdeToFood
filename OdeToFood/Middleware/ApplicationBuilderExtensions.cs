using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Custom Middleware used to set up a seperate location for serving static files.
        /// Specific to the folder we want to serve files from.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="root"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseNodeModules(this IApplicationBuilder app, string root)
        {
            // Create a path from the root path/string passed in and then the node_modules folder
            var path = Path.Combine(root, "node_modules");

            // Set up the path to the node_modules folder as a File Provider so we can set it up for our File Options object
            var provider = new PhysicalFileProvider(path);

            // Create an options object to hold any options needed for StaticFiles using node_modules folder
            var options = new StaticFileOptions();

            // Ignore any requests if they don't beging with /node_modules
            options.RequestPath = "/node_modules";

            // Where to look for the files
            options.FileProvider = provider;

            app.UseStaticFiles();
            return app;
        }
    }
}
