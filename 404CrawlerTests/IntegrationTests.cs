using System.Collections;
using System.Diagnostics;
using System.Net;
using _404Crawler;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _404CrawlerTests
{
    [TestClass]
    public class IntegrationTests
    {
        Process cmd;

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

            // TODO: Change to extract path here to app.config file so it can be changed for different machines
            cmd.StandardInput.WriteLine("cd /Users/danielmassarano/Projects/MVCTestApp/MVCTestApp/");
            cmd.StandardInput.WriteLine("dotnet run MVCTestApp.csproj");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
        }

        [TestMethod]
        public void GetHeaderReturnsOKForGoodLinkTest()
        {
            WebHandler handler = new WebHandler();
            string url = "https://localhost:5001";

            HttpStatusCode header = handler.GetHeader(url);

            Assert.AreEqual(HttpStatusCode.OK, header);
        }

        [TestMethod]
        public void GetHeaderReturnsUnavailableForBadLinkTest()
        {
            WebHandler handler = new WebHandler();
            string url = "https://localhost:5001/badpage";

            HttpStatusCode header = handler.GetHeader(url);

            Assert.AreEqual(HttpStatusCode.NotFound, header);
        }

        [TestMethod]
        public void ScrapeLinksReturnsCorrectNumber()
        {
            WebHandler handler = new WebHandler();
            string url = "https://localhost:5001";

            ArrayList result = handler.ScrapeLinks(url);

            Assert.AreEqual(24, result.Count);
        }
    }
}