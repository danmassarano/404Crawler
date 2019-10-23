using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;

namespace _404Crawler
{
    public class Crawler
    {
        public string startPage;

        public Crawler(string page)
        {
            startPage = page;
        }


        private List<string> links;
        private List<Link> allLinks;

        Output output = new Output();
        WebHandler handler = new WebHandler();

        internal readonly string externalSiteRegex = @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";
        internal readonly string internalSiteRegex = @"^\/{1}[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";

        //TODO: complete method
        // crawl()
            // for each link in links
                // if link !tested (not in allLinks or is flagged tested = false
                    // print link
                    // check link exists
                    // add to allLinks (URL, pass/fail, tested)
                    // if exists
                        // List<string> newLinks = addNewLinks(link)
                        // crawl(newLinks)
        // TODO how does it process or ourput results?


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
            ArrayList nextPage = handler.ScrapeLinks(link.ToString());
            //TODO: Call RemoveDuplicateLinks here;

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
            return handler.GetHeader(link.ToString()).Equals(HttpStatusCode.OK);
        }

        /// <summary>
        /// Checks if a given link is internal or external.
        /// This looks for links that start with the same domain as the original page checked
        /// </summary>
        /// <param name="link">URL of web page to check</param>
        /// <returns>True of link is internal to the site - i.e. the domain matches
        /// that of the original page</returns>
        public bool IsInternalLinkWithDomain(object link)
        {
            return link.ToString().StartsWith(startPage, StringComparison.CurrentCulture);
        }

        /// <summary>
        /// Checks if a given link is internal or external.
        /// This looks for links that use a relative path rather than an absolute one.
        /// (eg <c>/home/about/</c>)a`
        /// </summary>
        /// <param name="link">URL of web page to be checked</param>
        /// <returns>True if link is internal to the site and uses a relative filepath</returns>
        public bool IsInternalLinkWithoutDomain(object link)
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
        public bool IsExternalLink(object link)
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
