using System;
using System.Collections;
using System.Net;
using HtmlAgilityPack;

namespace _404Crawler
{
    /// <summary>
    /// Web handler class is used to make any web requests used in the crawler
    /// </summary>
    public class WebHandler
    {
        public string StartPage { get; set; }
        internal readonly string externalSiteRegex = @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";
        internal readonly string internalSiteRegex = @"^\/{1}[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";

        /// <summary>
        /// Checks returned header of a webpage for it's status code. 
        /// Used to see if a webpage is working or not
        /// </summary>
        /// <returns>HTTP status code</returns>
        /// <param name="url">URL</param>
        public HttpStatusCode GetHeader(string url)
        {
            //TODO: Improve error handling for invalid and null links
            HttpStatusCode result = default(HttpStatusCode);

            var request = WebRequest.Create(url);
            request.Method = "HEAD";
            try
            {
                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    if (response != null)
                    {
                        result = response.StatusCode;
                        response.Close();
                    }
                }
            }
            catch (Exception)
            {
                //TODO: remove and test
                result = HttpStatusCode.Ambiguous;
                Console.WriteLine("============================================");
                Console.WriteLine(result);
                Console.WriteLine("============================================");
            }
            Console.WriteLine("============================================");
            Console.WriteLine(result);
            Console.WriteLine("============================================");

            return result;
        }

        /// <summary>
        /// Takes all links from an HTML web page and stores them in a list
        /// </summary>
        /// <returns>ArrayList of all links</returns>
        /// <param name="url">URL</param>
        public ArrayList ScrapeLinks(string url)
        {
            HtmlWeb site = new HtmlWeb();
            ArrayList links = new ArrayList();
            HtmlDocument page = site.Load(url);

            foreach (HtmlNode link in page.DocumentNode.SelectNodes("//a[@href]"))
            {
                if (!links.Contains(link.Attributes["href"].Value))
                {
                    links.Add(link.Attributes["href"].Value);
                    Console.WriteLine($"{link.Attributes["href"].Value} : Added to list");
                }
            }
            return links;
        }

        /// <summary>
        /// Checks for all links on a webpage and adds them to a list
        /// </summary>
        /// <param name="pagesToProcess">ArrayList containing all links being checked</param>
        /// <param name="link">URL of web page to check</param>
        /// <returns>ArrayList updated with new links</returns>
        public ArrayList AddNewLinks(ArrayList pagesToProcess, object link)
        {
            Console.WriteLine($"{link.ToString()} : OK");
            ArrayList nextPage = ScrapeLinks(link.ToString());

            foreach (var newLink in nextPage)
            {
                pagesToProcess.Add(newLink);
            }

            return pagesToProcess;
        }
    }
}
