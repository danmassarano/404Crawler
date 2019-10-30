using System.Collections;
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

        //Process cmd;
        // TODO: SETUP/TEARDOWN TEST APP
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

        //TODO: Extract localhost strings to a local variable so it can easily be changed
        [TestMethod]
        [TestCategory("GetHeader")]
        public void GetHeaderValidURLTest()
        {
            var handler = new WebHandler();
            var expected = HttpStatusCode.OK;

            var result = handler.GetHeader("https://localhost:5001");

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [TestCategory("GetHeader")]
        public void GetHeaderInvalidURLTest()
        {
            var handler = new WebHandler();
            var expected = HttpStatusCode.OK;

            var result = handler.GetHeader("https://localhost:5001/fake");

            Assert.AreNotEqual(expected, result);
        }

        [TestMethod]
        [TestCategory("GetHeader")]
        [ExpectedException(typeof(System.UriFormatException),
            "Invalid URI: The format of the URI could not be determined.")]
        public void GetHeaderInvalidFormatTest()
        {
            // TODO: move to scrape links 
            var handler = new WebHandler();

            _ = handler.GetHeader("fake");
        }

        [TestMethod]
        [TestCategory("ScrapeLinks")]
        public void ScrapeLinksTest()
        {
            // TODO: Update test method
            var handler = new WebHandler();
            var expected = 4;

            var result = WebHandler.ScrapeLinks(handler, "https://localhost:5001/Home/About").Count;

            Assert.AreEqual(expected, result);
        }
    }
}
