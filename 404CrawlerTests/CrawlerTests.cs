using _404Crawler;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _404CrawlerTests
{
    /// <summary>
    /// Unit tests for Crawler class, tests all business logic for application
    /// </summary>
    [TestClass]
    public class CrawlerTests
    {
        private readonly string StartPage = "https://localhost:5001";

        [TestMethod]
        [TestCategory("GetCompleteURL")]
        public void GetCompleteURLIsInternalTest()
        {
            Crawler crawler = new Crawler(StartPage);
            string expected = StartPage + "/Home/About";

            string result = crawler.GetCompleteURL("/Home/About");

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [TestCategory("Online")]
        [TestCategory("PageExists")]
        public void PageExistsTrueTest()
        {
            Crawler crawler = new Crawler("https://go.microsoft.com/fwlink/?LinkID=517853");
            bool expected = true;

            bool result = crawler.PageExists("https://go.microsoft.com/fwlink/?LinkID=517853");

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [TestCategory("Online")]
        [TestCategory("PageExists")]
        public void PageExistsFalseTest()
        {
            Crawler crawler = new Crawler("example.com");
            bool expected = false;

            bool result = crawler.PageExists("example.com/fake");

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [TestCategory("CheckLinkType")]
        [TestCategory("IsInternalLinkWithDomain")]
        public void IsInternalLinkWithDomainTrueTest()
        {
            string link = "example.com/about";
            bool expected = true;
            Crawler crawler = new Crawler(link);

            bool result = crawler.IsInternalLinkWithDomain(link);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [TestCategory("CheckLinkType")]
        [TestCategory("IsInternalLinkWithDomain")]
        public void IsInternalLinkWithDomainFalseTest()
        {
            string page = "example.com";
            string link = "/about";
            bool expected = false;
            Crawler crawler = new Crawler(page);

            bool result = crawler.IsInternalLinkWithDomain(link);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [TestCategory("CheckLinkType")]
        [TestCategory("IsInternalLinkWithoutDomain")]
        public void IsInternalLinkWithoutDomainTrueTest()
        {
            string page = "example.com";
            string link = "/about";
            bool expected = true;
            Crawler crawler = new Crawler(page);

            bool result = crawler.IsInternalLinkWithoutDomain(link);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [TestCategory("CheckLinkType")]
        [TestCategory("IsInternalLinkWithoutDomain")]
        public void IsInternalLinkWithoutDomainFalseTest()
        {
            string link = "https://go.microsoft.com";
            bool expected = false;
            Crawler crawler = new Crawler(link);

            bool result = crawler.IsInternalLinkWithoutDomain(link);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [TestCategory("CheckLinkType")]
        [TestCategory("IsExternalLink")]
        public void IsExternalLinkTrueTest()
        {
            string link = "https://go.microsoft.com";
            bool expected = true;
            Crawler crawler = new Crawler(StartPage);

            bool result = crawler.IsExternalLink(link);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [TestCategory("CheckLinkType")]
        [TestCategory("IsExternalLink")]
        public void IsExternalLinkFalseTest()
        {
            string link = StartPage;
            bool expected = false;
            Crawler crawler = new Crawler(StartPage);

            bool result = crawler.IsExternalLink(link);

            Assert.AreEqual(expected, result);
        }
    }
}
