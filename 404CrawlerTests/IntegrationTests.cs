using System.Collections;
using System.Diagnostics;
using System.Net;
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
            // TODO: Add commands to kill processes running on needed ports
            // TODO: Change to extract path here to app.config file so it can be changed for different machines
            cmd.StandardInput.WriteLine("cd /Users/danielmassarano/Projects/MVCTestApp/MVCTestApp/");
            cmd.StandardInput.WriteLine("dotnet run MVCTestApp.csproj");
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

        /*
         * CrawlerHasInvalidURLTest
         * CrawlerHasPageWithNoLinksTest
         * CrawlerHasPagesWithAllValidURLsTest
         * CrawlerHasPagesWithAllInvalidURLsTest
         * CrawlerHasPagesWithSomeInvalidURLsTest
         */
    }
}