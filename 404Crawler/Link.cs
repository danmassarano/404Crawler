namespace _404Crawler
{
    public class Link
    {
        public string Name;
        public string URL;
        public bool Passed;
        public bool Internal;

        public Link(string name, string url, bool passed, bool isInternal)
        {
            Name = name;
            URL = url;
            Passed = passed;
            Internal = isInternal;
        }
    }
}
