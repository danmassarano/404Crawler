using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _404CrawlerTests
{
    /// <summary>
    /// Unit tests for Crawler class, tests all business logic for application
    /// </summary>
    [TestClass]
    public class CrawlerTests
    {
        // TODO: How am I testing the Crawl() class - should that fall under integration tests?

        [TestMethod]
        [TestCategory("Constructor")]
        public void CrawlerTest()
        {
            // TODO: Complete test method
        }

        [TestMethod]
        [TestCategory("PrintCrawlerHeader")]
        public void PrintCrawlerHeaderTest()
        {
            // TODO: Complete test method
        }

        [TestMethod]
        [TestCategory("GetCompleteURL")]
        public void GetCompleteURLIsInternal()
        {
            // TODO: Complete test method
        }

        [TestMethod]
        [TestCategory("GetCompleteURL")]
        public void GetCompleteURLIsExternal()
        {
            // TODO: Complete test method
        }

        [TestMethod]
        [TestCategory("Online")]
        [TestCategory("PageExists")]
        public void PageExistsTrueTest()
        {
            // TODO: Update test method
            var handler = new WebHandler();
            var expected = true;

            var result = handler.PageExists("https://localhost:5001");

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [TestCategory("Online")]
        [TestCategory("PageExists")]
        public void PageExistsFalseTest()
        {
            // TODO: Update test method
            var handler = new WebHandler();
            var expected = false;

            var result = handler.PageExists("https://localhost:5001/fake");

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [TestCategory("LinkTested")]
        public void LinkTestedTrueTest()
        {
            // TODO: Complete test method
        }

        [TestMethod]
        [TestCategory("LinkTested")]
        public void LinkTestedFalseTest()
        {
            // TODO: Complete test method
        }

        [TestMethod]
        [TestCategory("CheckLinkType")]
        [TestCategory("IsInternalLinkWithDomain")]
        public void IsInternalLinkWithDomainTrueTest()
        {
            // TODO: Update test method
            WebHandler handler = new WebHandler();
            bool expected = true;
            string link = "example.com/about";

            handler.StartPage = "example.com";

            bool result = handler.IsInternalLinkWithDomain(link);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [TestCategory("CheckLinkType")]
        [TestCategory("IsInternalLinkWithDomain")]
        public void IsInternalLinkWithDomainFalseTest()
        {
            // TODO: Update test method
            WebHandler handler = new WebHandler();
            bool expected = false;
            string link = "/about";

            handler.StartPage = "example.com";

            bool result = handler.IsInternalLinkWithDomain(link);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [TestCategory("CheckLinkType")]
        [TestCategory("IsInternalLinkWithoutDomain")]
        public void IsInternalLinkWithoutDomainTrueTest()
        {
            // TODO: Update test method
            WebHandler handler = new WebHandler();
            bool expected = true;
            string link = "/about";

            handler.StartPage = "example.com";

            bool result = handler.IsInternalLinkWithoutDomain(link);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [TestCategory("CheckLinkType")]
        [TestCategory("IsInternalLinkWithoutDomain")]
        public void IsInternalLinkWithoutDomainFalseTest()
        {
            // TODO: Update test method
            WebHandler handler = new WebHandler();
            bool expected = false;
            string link = "https://go.microsoft.com";

            handler.StartPage = "example.com";

            bool result = handler.IsInternalLinkWithoutDomain(link);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [TestCategory("CheckLinkType")]
        [TestCategory("IsExternalLink")]
        public void IsExternalLinkTrueTest()
        {
            // TODO: Update test method
            WebHandler handler = new WebHandler();
            bool expected = true;
            string link = "https://go.microsoft.com";

            handler.StartPage = "example.com";

            bool result = handler.IsExternalLink(link);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [TestCategory("CheckLinkType")]
        [TestCategory("IsExternalLink")]
        public void IsExternalLinkFalseTest()
        {
            // TODO: Update test method
            WebHandler handler = new WebHandler();
            bool expected = false;
            string link = "/about";

            handler.StartPage = "example.com";

            bool result = handler.IsExternalLink(link);

            Assert.AreEqual(expected, result);
        }
    }
}
