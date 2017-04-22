using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace OdeToFood
{
    public class Startup
    {
        // Property to hold the Configuration information 
        public IConfiguration Configuration { get; set; }

        /// <summary>
        /// Constructor used to build different parts of the config
        /// 
        /// The IHostingEnvrionment object env can tell what environment we are in, prod or dev.
        /// 
        /// AddJsonFile is a method used to add whatever json file you have set up with your configuration
        /// settings in it.
        ///     - Can have a connection string or other settings here.
        /// 
        /// AddEnvironmentVariables is not currently being used. 
        ///     -This is something that can be used if you ever want to override the
        ///      config.json variables.
        ///     -This is the value from the properties. if you right click the project and
        ///      go to properties you can set Environment Variables
        ///
        /// NuGet Dependencies:
        /// Microsoft.Extensions.Configuration.FileExtensions
        /// Microsoft.Extensions.Configuration.Json
        /// 
        /// </summary>
        public Startup(IHostingEnvironment env)
        {
            // Set up the configuration sources
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();

            // Have the builder build itself and assign to the Configuration property
            Configuration = builder.Build();
        }        

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            /* IGreeter now implements IConfiguration. Since that was created in this class we need to
             * register it as a service here. Use the Configuration property we created above from the IConfiguration.
             * 
             * Now whenever Configure is called it will see it needs an IGreeter object.
             * It will then look at that IGreeter class and see that it takes an IConfiguration object,
             * which is now set up here.
             */ 
            services.AddSingleton(Configuration);

            // Whenever something needs an IGreeter instantiate this class and pass it in
            services.AddSingleton<IGreeter, Greeter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app, 
            IHostingEnvironment env, 
            ILoggerFactory loggerFactory,
            IGreeter greeter)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                // Set the text on the web page to equal our text in the json settings
                var message = greeter.GetGreeting();
                await context.Response.WriteAsync(message);
            });
        }
    }
}
