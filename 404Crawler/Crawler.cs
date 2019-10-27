using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace _404Crawler
{
    /// <summary>
    /// The Crawler class contains all the app logic for the crawler
    /// </summary>
    public class Crawler
    {
        private readonly string startPage;

        private List<string> links = new List<string>();
        private readonly List<Link> allLinks = new List<Link>();

        readonly Output output = new Output();
        readonly WebHandler handler = new WebHandler();

        internal readonly string externalSiteRegex = @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";
        internal readonly string internalSiteRegex = @"^\/{1}[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";

        /// <summary>
        /// Constructor class used to create and call the crawler
        /// </summary>
        /// <param name="page">Full URL of web page to test</param>
        public Crawler(string page)
        {
            startPage = page;
            PrintCrawlerHeader();
        }

        /// <summary>
        /// Recursively tests all links pointed to in a web page
        /// </summary>
        /// <param name="pageToCrawl">URL of web page to check</param>
        public void Crawl(string pageToCrawl)
        {
            string urlToCrawl = GetCompleteURL(pageToCrawl);
            links = handler.ScrapeLinks(urlToCrawl);

            foreach (var link in links.ToList())
            {
                if (!LinkTested(link))
                {
                    Console.WriteLine($"{link} : Testing...");

                    System.Threading.Thread.Sleep(200);

                    bool exists = PageExists(link);
                    bool isInternal = LinkIsInternal(link);

                    allLinks.Add(new Link(pageToCrawl, link, exists, isInternal));

                    if (exists && isInternal)
                    {
                        Console.WriteLine($"{link} : Scraping from page...");
                        Crawl(link);
                    }
                }
            }
        }

        /// <summary>
        /// Prints out header and logo for crawler at start of program
        /// </summary>
        private void PrintCrawlerHeader()
        {
            Console.WriteLine(output.PrintLogo() + "\n" + output.PrintHeader(startPage));
        }

        /// <summary>
        /// Returns List of all links processed for results
        /// </summary>
        /// <returns>allLinks List</returns>
        public List<Link> GetAllLinksProcessed()
        {
            return allLinks;
        }

        /// <summary>
        /// Ensures that URL being tested is complete and not a relative path
        /// </summary>
        /// <param name="link">URL of web page to check</param>
        /// <returns>Complete URL of web page to check</returns>
        public string GetCompleteURL(string link)
        {
            string url = link;

            if (IsInternalLinkWithoutDomain(url))
            {
                url = string.Concat(startPage, url);
            }

            return url;
        }

        /// <summary>
        /// Checks if a page exists by getting its header and inspecting the HTTP response code
        /// </summary>
        /// <param name="link">URL of web page to check</param>
        /// <returns>True if page exists (ie header contains 200 response code)</returns>
        public bool PageExists(string link)
        {
            return handler.GetHeader(link).Equals(HttpStatusCode.OK);
        }

        /// <summary>
        /// Checks if link has already been tested or not
        /// Looks for link existing in allLinks - if there, it's been tested
        /// </summary>
        /// <param name="url">URL of web page to check</param>
        /// <returns>True if link has been tested</returns>
        private bool LinkTested(string url)
        {
            return allLinks.Any(l => l.Name == url.ToString() || l.URL == url.ToString());
        }

        /// <summary>
        /// Checks if a given link is internal or external.
        /// </summary>
        /// <param name="link">URL of web page to check</param>
        /// <returns>True of link is internal to the site</returns>
        private bool LinkIsInternal(string link)
        {
            return IsInternalLinkWithDomain(link) || IsInternalLinkWithoutDomain(link);
        }

        /// <summary>
        /// Checks if a given link is internal or external.
        /// This looks for links that start with the same domain as the original page checked
        /// </summary>
        /// <param name="link">URL of web page to check</param>
        /// <returns>True of link is internal to the site - i.e. the domain matches
        /// that of the original page</returns>
        public bool IsInternalLinkWithDomain(string link)
        {
            return link.StartsWith(startPage, StringComparison.CurrentCulture);
        }

        /// <summary>
        /// Checks if a given link is internal or external.
        /// This looks for links that use a relative path rather than an absolute one.
        /// (eg <c>/home/about/</c>)a`
        /// </summary>
        /// <param name="link">URL of web page to be checked</param>
        /// <returns>True if link is internal to the site and uses a relative filepath</returns>
        public bool IsInternalLinkWithoutDomain(string link)
        {
            RegexOptions options = RegexOptions.Multiline;

            foreach (Match m in Regex.Matches(link, internalSiteRegex, options))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if a given link has a valid URL - i.e. it looks like it should
        /// belong to a webpage
        /// </summary>
        /// <param name="link">URL of web page to be checked</param>
        /// <returns>True if URL is of a valid link pattern</returns>
        public bool IsExternalLink(string link)
        {
            RegexOptions options = RegexOptions.Multiline;

            foreach (Match m in Regex.Matches(link, externalSiteRegex, options))
            {
                return true;
            }
            return false;
        }
    }
}
