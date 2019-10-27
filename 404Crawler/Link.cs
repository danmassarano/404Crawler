namespace _404Crawler
{
    public class Link
    {
        public string Name;
        public string URL;
        public bool Passed;
        public bool External;

        public Link(string name, string url, bool passed, bool external)
        {
            Name = name;
            URL = url;
            Passed = passed;
            External = external;
        }
    }
}
