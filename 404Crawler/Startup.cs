using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace _404Crawler
{
    /// <summary>
    /// Sets up environment for app to run
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">Services</param>
        public void ConfigureServices(IServiceCollection services)
        {
            //TODO: What does this do? Remove? Test?
        }

        /// <summary>
        /// Configure the specified app and env.
        /// </summary>
        /// <param name="app">App</param>
        /// <param name="env">Env</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // TODO: Remove?
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
