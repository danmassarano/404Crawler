using System.Configuration;
using System.Diagnostics;
using System.Net;
using _404Crawler;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _404CrawlerTests
{
    /// <summary>
    /// Unit tests for WebHandler class, tests logic and web handling are correct
    /// Tests tagged as <c>Online</c> require the MVC Test app to be running on
    /// <c>localhost:5001</c>
    /// </summary>
    [TestClass]
    public class WebHandlerTests
    {
        private readonly string StartPage = "https://localhost:5001";
        Process cmd;

        /// <summary>
        /// Sets up environment for testing. A local webpage needs to booted up
        /// to run integration tests against. 
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            cmd = new Process();
            cmd.StartInfo.FileName = "/bin/bash";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = false;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();
            cmd.StandardInput.WriteLine(ConfigurationManager.AppSettings["projectPath"]);
            cmd.StandardInput.WriteLine(ConfigurationManager.AppSettings["projectName"]);
        }

        /// <summary>
        /// Tears down testing environment after testing is done. 
        /// </summary>
        [TestCleanup]
        public void TestCleanup()
        {
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
        }

        [TestMethod]
        [TestCategory("Online")]
        [TestCategory("GetHeader")]
        public void GetHeaderValidURLTest()
        {
            WebHandler handler = new WebHandler();
            HttpStatusCode expected = HttpStatusCode.OK;

            HttpStatusCode result = handler.GetHeader(StartPage);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [TestCategory("Online")]
        [TestCategory("GetHeader")]
        public void GetHeaderInvalidURLTest()
        {
            WebHandler handler = new WebHandler();
            HttpStatusCode expected = HttpStatusCode.OK;

            HttpStatusCode result = handler.GetHeader(StartPage + "/fake");

            Assert.AreNotEqual(expected, result);
        }

        [TestMethod]
        [TestCategory("Online")]
        [TestCategory("ScrapeLinks")]
        public void ScrapeLinksTest()
        {
            WebHandler handler = new WebHandler();
            int expected = 3;

            int result = handler.ScrapeLinks(StartPage + "/Home/About").Count;

            Assert.AreEqual(expected, result);
        }
    }
}
