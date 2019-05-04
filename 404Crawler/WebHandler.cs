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
        /// <summary>
        /// Checks returned header of a webpage for it's status code. 
        /// Used to see if a webpage is working or not
        /// </summary>
        /// <returns>HTTP status code</returns>
        /// <param name="url">URL</param>
        public HttpStatusCode GetHeader(string url)
        {
            //TODO: Add handling for null or empty url added
            //TODO: Switch to async
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
            catch (WebException e)
            {
                result = ((HttpWebResponse)e.Response).StatusCode;
            }

            return result;
        }

        /// <summary>
        /// Takes all URL's from an HTML web page and stores them in a list
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
                }
            }
            return links;
        }

        // TODO: Create method that sorts list into links to just check header, and links to get full page
    }
}
