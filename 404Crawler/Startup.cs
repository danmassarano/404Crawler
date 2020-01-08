using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace _404Crawler
{
    /// <summary>
    /// Sets up environment for app to run
    /// </summary>
    public class Startup
    {
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
        }
    }
}
