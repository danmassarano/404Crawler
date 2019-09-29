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
        [TestCategory("Integration")]
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
        [TestCategory("Integration")]
        public void TestCleanup()
        {
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("Input")]
        public void CrawlerHasInvalidURLTest()
        {
            //TODO fix error handling for this first, maybe just remove exception message

            // Fix error handling, get expected result as string
            // Add 'expected exception' tag
            // How do I start the program from here and read console?
            // Start program, pass nonsense URL
            // Assert output is correct
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("Input")]
        public void CrawlerHasNullURLTest()
        {
            // get expected result as string
            // Add 'expected exception' tag
            // Start program, pass null URL
            // Assert output is correct
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("Crawler")]
        public void TimeoutIsCaughtByException()
        {
            // How can I force a timeout?
            // get expected result as string
            // Add 'expected exception' tag
            // Start program, pass localhost URL
            // Assert output is correct
        }

        [TestMethod]
        [TestCategory("Integration")]
        [TestCategory("Crawler")]
        public void CrawlerHasPagesAndResultsTest()
        {
            // get expected result as number of pages processed, passed and failed
            // Start program, pass localhost URL
            // Assert output is correct
        }
    }
}