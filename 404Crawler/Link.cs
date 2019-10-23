namespace _404Crawler
{
    public class Link
    {
        string URL { get; set; }

        bool Tested { get; set; }

        bool Passed { get; set; }

        public Link(string url, bool tested, bool passed)
        {
            URL = url;
            Tested = tested;
            Passed = passed;
        }
    }
}
