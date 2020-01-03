using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using _404Crawler;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _404CrawlerTests
{
    /// <summary>
    /// Integration tests for project.
    /// Thses tests run against a generated web page, which first needs to be 
    /// booted up in <code>TestInitialize</code>
    /// </summary>
    [TestClass]
    public class IntegrationTests
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
        [TestCategory("Crawler")]
        public void CrawlerHasPagesAndResultsTest()
        {
            Crawler crawler = new Crawler(StartPage);
            Output output = new Output();

            int expectedProcessed = 22;
            int expectedPassed = 13;

            crawler.Crawl(StartPage);
            List<Link> results = crawler.GetAllLinksProcessed();

            Assert.AreEqual(expectedProcessed, results.Count);
            Assert.AreEqual(expectedPassed, results.FindAll(l => l.Passed == true).Count);
        }
    }
}