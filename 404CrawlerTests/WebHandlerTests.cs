using System.Collections;
using System.Diagnostics;
using System.Net;
using _404Crawler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace _404CrawlerTests
{
    [TestClass]
    public class WebHandlerTests
    {

        //Process cmd;

        ///// <summary>
        ///// Sets up environment for testing. A local webpage needs to booted up
        ///// to run integration tests against. 
        ///// </summary>
        //[TestInitialize]
        //public void TestInitialize()
        //{
        //    cmd = new Process();
        //    cmd.StartInfo.FileName = "/bin/bash";
        //    cmd.StartInfo.RedirectStandardInput = true;
        //    cmd.StartInfo.RedirectStandardOutput = true;
        //    cmd.StartInfo.CreateNoWindow = false;
        //    cmd.StartInfo.UseShellExecute = false;
        //    cmd.Start();
        //    // TODO: Add commands to kill processes running on needed ports
        //    // TODO: Change to extract path here to app.config file so it can be changed for different machines
        //    cmd.StandardInput.WriteLine("cd /Users/danielmassarano/Projects/MVCTestApp/MVCTestApp/");
        //    cmd.StandardInput.WriteLine("dotnet run MVCTestApp.csproj");
        //}

        ///// <summary>
        ///// Tears down testing environment after testing is done. 
        ///// </summary>
        //[TestCleanup]
        //public void TestCleanup()
        //{
        //    cmd.StandardInput.Flush();
        //    cmd.StandardInput.Close();
        //    cmd.WaitForExit();
        //}


        [TestMethod]
        [TestCategory("GetHeader")]
        public void GetHeaderValidURLTest()
        {
            //TODO: how to mock http requests?
            //var response = new Mock<HttpWebResponse>(MockBehavior.Loose);
            //response.Setup(c => c.StatusCode).Returns(HttpStatusCode.OK);

            //var request = new Mock<HttpWebRequest>();
            //request.Setup(s => s.GetResponse()).Returns(response.Object);
            //NextRequest = request.Object;
            //return request.Object;
        }

        [TestMethod]
        [TestCategory("GetHeader")]
        public void GetHeaderInvalidURLTest()
        {
            // returns an exception
        }

        [TestMethod]
        [TestCategory("GetHeader")]
        public void GetHeaderUnresponsiveURLTest()
        {
            // force a timeout and return exception
        }

        [TestMethod]
        [TestCategory("ScrapeLinks")]
        public void ScrapeLinksTest()
        {
            // might have to set up and tear down mvc, then check number of links
        }

        [TestMethod]
        [TestCategory("ScrapeLinks")]
        public void ScrapeLinksWithNoLinksTest()
        {
            // might have to set up and tear down mvc, then check number of links
        }

        [TestMethod]
        [TestCategory("RemoveDuplicateLinks")]
        public void RemoveDuplicateLinksWithoutDuplicatesTest()
        {
            ArrayList pagesToProcess = new ArrayList
            {
                "https://go.microsoft.com/fwlink/?LinkID=398939"
            };
            ArrayList pagesProcessed = new ArrayList
            {
                "https://go.microsoft.com/fwlink/?LinkID=525028&clcid=0x409"
            };
            ArrayList expected = new ArrayList
            {
                "https://go.microsoft.com/fwlink/?LinkID=398939"
            };

            WebHandler handler = new WebHandler();
            ArrayList result = handler.RemoveDuplicateLinks(pagesToProcess, pagesProcessed);

            Assert.AreEqual(expected.ToString(), result.ToString());
        }

        [TestMethod]
        [TestCategory("RemoveDuplicateLinks")]
        public void RemoveDuplicateLinksWithDuplicatesTest()
        {
            ArrayList pagesToProcess = new ArrayList
            {
                "https://go.microsoft.com/fwlink/?LinkID=525028&clcid=0x409",
                "https://go.microsoft.com/fwlink/?LinkID=398939"
            };
            ArrayList pagesProcessed = new ArrayList
            {
                "https://go.microsoft.com/fwlink/?LinkID=525028&clcid=0x409"
            };
            ArrayList expected = new ArrayList
            {
                "https://go.microsoft.com/fwlink/?LinkID=398939"
            };

            WebHandler handler = new WebHandler();
            ArrayList result = handler.RemoveDuplicateLinks(pagesToProcess, pagesProcessed);

            Assert.AreEqual(expected.ToString(), result.ToString());
        }

        [TestMethod]
        [TestCategory("RemoveDuplicateLinks")]
        public void RemoveDuplicateLinksWithHashTest()
        {
            ArrayList pagesToProcess = new ArrayList
            {
                "https://go.microsoft.com/fwlink/?LinkID=398939",
                "#"
            };
            ArrayList pagesProcessed = new ArrayList();
            ArrayList expected = new ArrayList
            {
                "https://go.microsoft.com/fwlink/?LinkID=398939"
            };

            WebHandler handler = new WebHandler();
            ArrayList result = handler.RemoveDuplicateLinks(pagesToProcess, pagesProcessed);

            Assert.AreEqual(expected.ToString(), result.ToString());
        }

        [TestMethod]
        [TestCategory("RemoveDuplicateLinks")]
        public void RemoveDuplicateLinksWithMailtoTest()
        {
            ArrayList pagesToProcess = new ArrayList
            {
                "https://go.microsoft.com/fwlink/?LinkID=398939",
                "mailto"
            };
            ArrayList pagesProcessed = new ArrayList();
            ArrayList expected = new ArrayList
            {
                "https://go.microsoft.com/fwlink/?LinkID=398939"
            };

            WebHandler handler = new WebHandler();
            ArrayList result = handler.RemoveDuplicateLinks(pagesToProcess, pagesProcessed);

            Assert.AreEqual(expected.ToString(), result.ToString());
        }

        [TestMethod]
        [TestCategory("RemoveDuplicateLinks")]
        public void RemoveDuplicateLinksWithSlashTest()
        {
            ArrayList pagesToProcess = new ArrayList
            {
                "https://go.microsoft.com/fwlink/?LinkID=398939",
                "/"
            };
            ArrayList pagesProcessed = new ArrayList();
            ArrayList expected = new ArrayList
            {
                "https://go.microsoft.com/fwlink/?LinkID=398939"
            };

            WebHandler handler = new WebHandler();
            ArrayList result = handler.RemoveDuplicateLinks(pagesToProcess, pagesProcessed);

            Assert.AreEqual(expected.ToString(), result.ToString());
        }

        [TestMethod]
        [TestCategory("AddNewLinks")]
        public void AddNewLinksWithNewLinksTest()
        {
            // pass arrays and check result
        }

        [TestMethod]
        [TestCategory("AddNewLinks")]
        public void AddNewLinksWithNoNewLinksTest()
        {
            // pass arrays and check result
        }

        [TestMethod]
        [TestCategory("PageExists")]
        public void PageExistsTrueTest()
        {
            // mock httprequest or startup/teardown mvc
        }

        [TestMethod]
        [TestCategory("PageExists")]
        public void PageExistsFalseTest()
        {
            // mock httprequest or startup/teardown mvc
        }

        [TestMethod]
        [TestCategory("CheckLinkType")]
        [TestCategory("IsInternalLinkWithDomain")]
        public void IsInternalLinkWithDomainTrueTest()
        {
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
            WebHandler handler = new WebHandler();
            bool expected = false;
            string link = "/about";

            handler.StartPage = "example.com";

            bool result = handler.IsExternalLink(link);

            Assert.AreEqual(expected, result);
        }
    }
}
