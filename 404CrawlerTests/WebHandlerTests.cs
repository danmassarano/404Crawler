using System.Collections;
using System.Net;
using _404Crawler;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _404CrawlerTests
{
    [TestClass]
    public class WebHandlerTests
    {
        //TODO: Use Mock to do unit testing where possible
        [TestMethod]
        public void Test()
        {
        }

        //[TestCategory("GetHeader")]
        //[TestMethod]
        //public void GetHeaderInvalidURLTest()
        //{
        //    WebHandler handler = new WebHandler();
        //    string url = "https://localhost:5001";

        //    HttpStatusCode header = handler.GetHeader(url);

        //    Assert.AreEqual(HttpStatusCode.OK, header);
        //}

        //[TestCategory("GetHeader")]
        //[TestMethod]
        //public void GetHeaderUnresponsiveURLTest()
        //{
        //    WebHandler handler = new WebHandler();
        //    string url = "https://localhost:5001/badpage";

        //    HttpStatusCode header = handler.GetHeader(url);

        //    Assert.AreEqual(HttpStatusCode.NotFound, header);
        //}

        //TODO:
        //GetHeaderValidURLTest

        //[TestCategory("ScrapeLinks")]
        //[TestMethod]
        //public void ScrapeLinksTest()
        //{
        //    WebHandler handler = new WebHandler();
        //    string url = "https://localhost:5001";

        //    ArrayList result = handler.ScrapeLinks(url);

        //    Assert.AreEqual(24, result.Count);
        //}

        /*
         * ScrapeLinksWithNoLinksTest
         * RemoveDuplicateLinksWithDuplicatesTest
         * RemoveDuplicateLinksWithoutDuplicatesTest
         * AddNewLinksWithNewLinksTest
         * AddNewLinksWithNoNewLinksTest
         * PageExistsTrueTest
         * PageExistsFalseTest
         * IsInternalLinkWithDomainTrueTest
         * IsInternalLinkWithDomainFalseTest
         * IsInternalLinkWithoutDomainTrueTest
         * IsInternalLinkWithoutDomainFalseTest
         * IsExternalLinkTrueTest
         * IsExternalLinkFalseTest
         */
    }
}
