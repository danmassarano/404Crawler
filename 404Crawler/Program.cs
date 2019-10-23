using System;
using System.Collections;

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
            Output output = new Output();
            WebHandler handler = new WebHandler();


            ArrayList pagesProcessed = new ArrayList();
            ArrayList pagesToProcess = new ArrayList();
            ArrayList pagesFailed = new ArrayList();
            ArrayList NewPagesFound = new ArrayList();

            int numPagesPassed = 0;
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

                handler.StartPage = startPage;
                Crawler crawler = new Crawler(startPage);
                Console.WriteLine(output.PrintLogo());
                Console.WriteLine("\n" + output.PrintHeader(startPage));




                pagesToProcess = handler.ScrapeLinks(startPage);
                pagesToProcess = crawler.RemoveDuplicateLinks(pagesToProcess, pagesProcessed);

                foreach (var link in pagesToProcess)
                {
                    Console.WriteLine($"Checking link: {link.ToString()}");

                    if (crawler.IsInternalLinkWithDomain(link) && crawler.PageExists(link))
                    {
                        NewPagesFound = handler.AddNewLinks(NewPagesFound, link);
                        numPagesPassed++;
                    }
                    else if (crawler.IsInternalLinkWithoutDomain(link))
                    {
                        if (crawler.PageExists(string.Concat(startPage, link)))
                        {
                            NewPagesFound = handler.AddNewLinks(NewPagesFound, string.Concat(startPage, link));
                            numPagesPassed++;
                        }
                    }
                    else if (crawler.IsExternalLink(link) && crawler.PageExists(link))
                    {
                        numPagesPassed++;
                    }
                    else
                    {
                        Console.WriteLine($"{link} : Page does not exist");
                        pagesFailed.Add(link);
                    }

                    pagesProcessed.Add(link);
                }

                Console.WriteLine(output.PrintResults(pagesProcessed, pagesFailed, numPagesPassed));

                pagesToProcess = crawler.RemoveDuplicateLinks(NewPagesFound, pagesProcessed);
                Console.WriteLine(output.PrintNewLinks(pagesToProcess));





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
