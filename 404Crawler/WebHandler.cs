using System;
using System.Collections.Generic;
using System.Net;
using HtmlAgilityPack;
using NLog;

namespace _404Crawler
{
    /// <summary>
    /// Web handler class is used to make any web requests used in the crawler
    /// </summary>
    public class WebHandler
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Checks returned header of a webpage for it's status code. 
        /// Used to see if a webpage is working or not
        /// </summary>
        /// <returns>HTTP status code</returns>
        /// <param name="url">URL</param>
        public HttpStatusCode GetHeader(string url)
        {
            HttpStatusCode result = default;

            try
            {
                WebRequest request = WebRequest.Create(url);
                request.Method = "HEAD";
                if (request.GetResponse() is HttpWebResponse response)
                {
                    result = response.StatusCode;
                    Logger.Info($"{url} : {result}");
                    response.Close();
                }
            }
            catch (Exception)
            {
                result = HttpStatusCode.NotFound;
                Logger.Warn($"{url} : {result}");
            }

            return result;
        }

        /// <summary>
        /// Takes all links from an HTML web page and stores them in a list
        /// </summary>
        /// <returns>List of all links</returns>
        /// <param name="url">URL</param>
        public List<string> ScrapeLinks(string url)
        {
            List<string> links = new List<string>();
            HtmlWeb site = new HtmlWeb();

            try
            {
                HtmlDocument page = site.Load(url);

                foreach (HtmlNode link in page.DocumentNode.SelectNodes("//a[@href]"))
                {
                    if (!links.Contains(link.Attributes["href"].Value))
                    {
                        string newLink = link.Attributes["href"].Value;
                        if (!newLink.StartsWith("#", StringComparison.CurrentCulture)
                            && !newLink.StartsWith("mailto", StringComparison.CurrentCulture)
                            && !newLink.Equals("/"))
                        {
                            links.Add(newLink);
                            Logger.Info($"{newLink} : Added to list");
                        }
                    }
                }
            }
            catch (UriFormatException)
            {
                Logger.Error("Failed: Invalid URL input\n");
            }

            return links;
        }
    }
}
