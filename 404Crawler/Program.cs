using System;

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
        /// lsof -i :5001
        /// kill -9 -> results
        /// dotnet run MVCTestApp.csproj
        /// 
        /// Now listening on: https://localhost:5001 
        /// Now listening on: http://localhost:5000
        /// 
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        public static void Main(string[] args)
        {
            string startPage;

            try
            {
                if (args.Length > 1)
                {
                    startPage = args[1];
                    Console.WriteLine(args[1] + "\n");
                }
                else
                {
                    //startPage = "https://localhost:5001";
                    Console.Write("Enter URL of site to test: ");
                    startPage = Console.ReadLine();
                }

                Crawler crawler = new Crawler(startPage);
                crawler.CrawlFirst();
            }
            catch (ArgumentNullException exception)
            {
                Console.WriteLine("Failed: No URL input");
                Console.WriteLine(exception);
            }
            catch (TimeoutException exception)
            {
                Console.WriteLine("Could not connect to target site");
                Console.WriteLine(exception);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Something unexpected happened");
                Console.WriteLine(exception);
            }
        }
    }
}
