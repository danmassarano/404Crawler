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
            Link link = new Link("example.com", "https://example.com", true, false, true);

            Assert.AreEqual("example.com", link.Name);
            Assert.IsTrue(link.SSLIsValid);
        }
    }
}
