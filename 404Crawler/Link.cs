namespace _404Crawler
{
    /// <summary>
    /// Link object stores all information about a given link 
    /// </summary>
    public class Link
    {
        public string Name;
        public string URL;
        public bool Passed;
        public bool Internal;

        /// <summary>
        /// Constructor class for link object
        /// </summary>
        /// <param name="name">Name of link before any string manupulation is performed</param>
        /// <param name="url">URL of link - might be different if provided link is relative</param>
        /// <param name="passed">Whether the link has been successfully tested</param>
        /// <param name="isInternal">Whether the link is internal to the site, or external</param>
        public Link(string name, string url, bool passed, bool isInternal)
        {
            Name = name;
            URL = url;
            Passed = passed;
            Internal = isInternal;
        }
    }
}
