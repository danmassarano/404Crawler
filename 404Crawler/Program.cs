using System;
using System.Net;

namespace _404Crawler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateWebHostBuilder(args).Build().Run();
            Console.WriteLine("Starting crawler...");
            /*
             * dotnet run MVCTestApp.csproj 
             * 
             * Now listening on: https://localhost:5001
             * Now listening on: http://localhost:5000            
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
