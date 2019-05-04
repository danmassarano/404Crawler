using System;
using System.Collections;
using System.Net;

namespace _404Crawler
{
    /// <summary>
    /// The main class for the program. 404Crawler is run from here. 
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        public static void Main(string[] args)
        {
            ArrayList pagesProcessed = new ArrayList();
            ArrayList pagesToProcess = new ArrayList();
            int totalPages = 0;
            int pagesPassed = 0;
            int pagesFailed = 0;

            //CreateWebHostBuilder(args).Build().Run();
            Console.WriteLine("Starting crawler...");
            /*
             * dotnet run MVCTestApp.csproj 
             * 
             * Now listening on: https://localhost:5001
             * Now listening on: http://localhost:5000      
             *
             * dotnet test
             *
             * https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-test?tabs=netcore21
             *
             */

            WebHandler handler = new WebHandler();
            Console.WriteLine("Checking https://localhost:5001");
            HttpStatusCode header = handler.GetHeader("https://localhost:5001");
            Console.WriteLine(header);

            Console.WriteLine("Checking https://localhost:5001/badpage");
            HttpStatusCode badHeader = handler.GetHeader("https://localhost:5001/badpage");
            Console.WriteLine(badHeader);
            Console.WriteLine("Stopping crawler...");

            pagesToProcess = handler.ScrapeLinks("https://localhost:5001");
            foreach (var link in pagesToProcess)
            {
                Console.WriteLine(link);
            }

            //public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            //WebHost.CreateDefaultBuilder(args)
            //.UseStartup<Startup>();
        }
    }
}
