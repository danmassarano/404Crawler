using _404Crawler;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _404CrawlerTests
{
    /// <summary>
    /// Unit tests for Links class, checks that Link objects are properly created and modified
    /// </summary>
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
