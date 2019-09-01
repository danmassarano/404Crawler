using System;
using System.Collections;
using System.Net;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace _404Crawler
{
    /// <summary>
    /// Web handler class is used to make any web requests used in the crawler
    /// </summary>
    public class WebHandler
    {
        // TODO should this be a static class? Might be easier to store arrays like that...

        public string StartPage { get; internal set; }
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
            catch (WebException exception)
            {
                result = ((HttpWebResponse)exception.Response).StatusCode;
            }
            catch (Exception)
            {
                result = HttpStatusCode.Ambiguous;
            }

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
            //if (page.DocumentNode.SelectNodes("//a[@href]") == null)
            //{
            //    return null;
            //}
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
        /// Removes any links that are either duplicates, link to the current page, or
        /// have already been checked
        /// </summary>
        /// <param name="pagesToProcess">ArrayList to check</param>
        /// <param name="pagesProcessed">ArrayList to check against for duplicates</param>
        /// <returns>Corrected ArrayList of pages to process</returns>
        public ArrayList RemoveDuplicateLinks(ArrayList pagesToProcess, ArrayList pagesProcessed)
        {
            var pagesToProcessTrimmed = new ArrayList();

            foreach (var link in pagesToProcess)
            {
                if (!pagesToProcessTrimmed.Contains(link)
                    && !pagesProcessed.Contains(link)
                    && !link.ToString().StartsWith("#", StringComparison.CurrentCulture)
                    && !link.ToString().StartsWith("mailto", StringComparison.CurrentCulture)
                    && !link.ToString().Equals("/"))
                {
                    pagesToProcessTrimmed.Add(link);
                }
                else
                {
                    Console.WriteLine($"{link.ToString()} : Removed from list");
                }
            }

            return pagesToProcessTrimmed;
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

        /// <summary>
        /// Checks if a page exists by getting its header and inspecting the HTTP response code
        /// </summary>
        /// <param name="link">URL of web page to check</param>
        /// <returns>True of page exists (ie header contains 200 response code)</returns>
        public bool PageExists(object link)
        {
            return GetHeader(link.ToString()).Equals(HttpStatusCode.OK);
        }

        /// <summary>
        /// Checks if a given link is internal or external.
        /// This looks for links that start with the same domain as the original page checked
        /// </summary>
        /// <param name="link">URL of web page to check</param>
        /// <returns>True of link is internal to the site - i.e. the domain matches
        /// that of the original page</returns>
        internal bool IsInternalLinkWithDomain(object link)
        {
            return link.ToString().StartsWith(StartPage, StringComparison.CurrentCulture);
        }

        /// <summary>
        /// Checks if a given link is internal or external.
        /// This looks for links that use a relative path rather than an absolute one.
        /// (eg <c>/home/about/</c>)a`
        /// </summary>
        /// <param name="link">URL of web page to be checked</param>
        /// <returns>True if link is internal to the site and uses a relative filepath</returns>
        internal bool IsInternalLinkWithoutDomain(object link)
        {
            RegexOptions options = RegexOptions.Multiline;

            foreach (Match m in Regex.Matches(link.ToString(), internalSiteRegex, options))
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
        internal bool IsExternalLink(object link)
        {
            RegexOptions options = RegexOptions.Multiline;

            foreach (Match m in Regex.Matches(link.ToString(), externalSiteRegex, options))
            {
                return true;
            }
            return false;
        }
    }
}
