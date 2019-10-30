using _404Crawler;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _404CrawlerTests
{
    [TestClass]
    public class LinkTests
    {
        [TestMethod]
        [TestCategory("Link")]
        public void LinkCreatedCorrectly()
        {
            Link link = new Link("example.com", "http://example.com", true, false);

            Assert.AreEqual("example.com", link.Name);
        }
    }
}
