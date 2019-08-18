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
        /// 
        /// TODO: Add shell commands to kill background processes
        /// dotnet run MVCTestApp.csproj
        /// 
        /// Now listening on: https://localhost:5001 
        /// Now listening on: http://localhost:5000
        /// 
        /// dotnet test
        /// 
        /// https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-test?tabs=netcore21
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        public static void Main(string[] args)
        {
            Output output = new Output();
            WebHandler handler = new WebHandler();

            ArrayList pagesProcessed = new ArrayList();
            ArrayList pagesToProcess = new ArrayList();
            ArrayList pagesFailed = new ArrayList();
            ArrayList NewPagesFound = new ArrayList();

            int numPagesPassed = 0;
            int numPagesFailed = 0;

            string startPage = "https://localhost:5001";
            handler.StartPage = startPage;

            //CreateWebHostBuilder(args).Build().Run();
            output.PrintHeader(startPage);
            
            pagesToProcess = handler.ScrapeLinks(startPage);
            pagesToProcess = handler.RemoveDuplicateLinks(pagesToProcess, pagesProcessed);

            foreach (var link in pagesToProcess)
            {
                Console.WriteLine($"Checking link: {link.ToString()}");

                if (handler.IsInternalLinkWithDomain(link) && handler.PageExists(link))
                {
                    NewPagesFound = handler.AddNewLinks(NewPagesFound, link);
                    Console.WriteLine($"{link.ToString()} : Added to list");
                    numPagesPassed++;
                }
                else if (handler.IsInternalLinkWithoutDomain(link))
                {
                    if (handler.PageExists(string.Concat(startPage, link)))
                    {
                        NewPagesFound = handler.AddNewLinks(NewPagesFound, string.Concat(startPage, link));
                        Console.WriteLine($"{string.Concat(startPage, link)} : Added to list");
                        numPagesPassed++;
                    }
                }
                else if (handler.IsExternalLink(link) && handler.PageExists(link))
                {
                    numPagesPassed++;
                }
                else
                {
                    Console.WriteLine($"{link} : Page does not exist");
                    pagesFailed.Add(link);
                    numPagesFailed++;
                }

                pagesProcessed.Add(link);
            }

            // TODO: Refactor to an outputResults method
            Console.WriteLine($"Total pages processed: {pagesProcessed.Count}");
            Console.WriteLine($"Total pages passed: {numPagesPassed}");
            Console.WriteLine($"Total pages failed: {numPagesFailed} : {pagesFailed.Count}");
            foreach (var link in pagesFailed)
            {
                Console.WriteLine($"{link.ToString()}");
            }

            pagesToProcess = handler.RemoveDuplicateLinks(NewPagesFound, pagesProcessed);
            Console.WriteLine($"Number of new pages to process : {pagesToProcess.Count}");
            Console.WriteLine($"New links found:");
            foreach (var link in pagesToProcess)
            {
                Console.WriteLine($"{link.ToString()}");
            }

            //public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            //WebHost.CreateDefaultBuilder(args)
            //.UseStartup<Startup>();
        }
    }
}
