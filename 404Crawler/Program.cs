using NLog;
using System;

namespace _404Crawler
{
    /// <summary>
    /// The main class for the program. 404Crawler is run from here. 
    /// </summary>
    public class Program
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

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
        /// <param name="args">The command line arguments.</param>
        public static void Main(string[] args)
        {
            try
            {
                var arguments = Environment.GetCommandLineArgs();

                string startPage;
                bool completed = false;

                for (int i = 0; i < arguments.Length; i++)
                {
                    if (arguments[i] == "-h" || arguments[i] == "--help")
                    {
                        Console.WriteLine(Help());
                        Environment.Exit(1);
                    }
                    else if (arguments[i] == "-s" || arguments[i] == "--source")
                    {
                        startPage = arguments[i + 1];
                        completed = Run(startPage);
                    }
                }

                if (!completed)
                {
                    Console.WriteLine("Usage: dotnet run 404Crawler.csproj " +
                                        "[-h || --help] " +
                                        "|| [-s || --source + <url>");
                }
                
            }
            catch (ArgumentNullException)
            {
                Logger.Fatal("Failed: No URL input. Try again with a valid link");
            }
            catch (TimeoutException)
            {
                Logger.Fatal("Could not connect to target site");
            }
            catch (Exception)
            {
                Logger.Fatal("Something unexpected happened");
            }
            finally
            {
                LogManager.Shutdown();
            }
        }

        /// <summary>
        /// Sets up and calls the crawler. Only called if arguments are valid
        /// </summary>
        /// <param name="startPage"></param>
        /// <returns>True if program completed successfully</returns>
        private static bool Run(string startPage)
        {
            Crawler crawler = new Crawler(startPage);
            Output output = new Output();

            crawler.Crawl(startPage);
            Logger.Info(output.PrintResults(crawler.GetAllLinksProcessed()));

            return true;
        }

        /// <summary>
        /// Prints out help information about program
        /// </summary>
        /// <returns></returns>
        private static string Help()
        {
            return "Crawler that displays how valid links in a website are " +
                    "\n\n" +
                    "Usage: dotnet run 404Crawler.csproj " +
                    "[-h || --help] || [-s || --source + <url>" +
                    "\n\n" +
                    "Point the crawler at the homepage of a site and it'll do the rest.";
        }
    }
}
