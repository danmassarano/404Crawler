using System;
using System.Collections;
using System.Net;

namespace _404Crawler
{
    public class Program
    {
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
        }

        //public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            //WebHost.CreateDefaultBuilder(args)
                //.UseStartup<Startup>();
    }
}
