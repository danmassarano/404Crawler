using _404Crawler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;

namespace _404CrawlerTests
{
    /// <summary>
    /// Unit tests for Output class, tests that console logs are accurate
    /// </summary>
    [TestClass]
    public class OutputTests
    {
        [TestMethod]
        [TestCategory("PrintHeader")]
        public void PrintHeaderTest()
        {
            Output output = new Output();
            string expected = "Starting crawler from https://www.google.com...";

            string result = output.PrintHeader("https://www.google.com");

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [TestCategory("PrintLogo")]
        public void PrintLogoTest()
        {
            Output output = new Output();
            string expected = "     |" +
                            "\n     |" +
                            "\n     |" +
                            "\n     |" +
                            "\n     |" +
                            "\n  /  |   \\" +
                            "\n ;_/,L-,\\_;" +
                            "\n\\._/3  E\\_./" +
                            "\n\\_./(::)\\._/" +
                            "\n     ''" +
                            "\n";

            string result = output.PrintLogo();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [TestCategory("PrintLogo")]
        public void PrintLargeLogoTest()
        {
            Output output = new Output();
            string expected = "lllloooooooooooooooooooooooooooddddddddddddddddddddddddddddddddddddddddddddddddd" +
                            "\nllllllooooooooooooooooooooooooddddddddddddddddddddc;oddddddddddddddddddddddddddd" +
                            "\nlllllloooooooooooooooooooddooddddddddddddddddddddd:'cddddddddddddddddddddddddddx" +
                            "\nllloooooooooooooooooooddo:;cdddddddddddddddddddddd:.:ddddddddddddddddddddddxxddd" +
                            "\nllllooooooooooooooooooo:',codddddddddodddddddddddd:.:dddddddddddddddxxxxdxxxxddx" +
                            "\nlllooooooooooooooooool,.;odddddddddddddddddddddddd;.:ddddddddddxxxxxxxxxxxxxxxxx" +
                            "\nllooooooooooooooooooc'.:oddddddddddddddddddddddddd,.cddddddxxxxxxxxxxxxxxxxxxxxx" +
                            "\noooooooooooooooooooc..:oddddddddddddddddddddddddxl..cdddxxdxxxxxxxxxxxxxxxxxxxxx" +
                            "\nlooooooooooooooooo:..:odddddddddddddddddddddddddo, .cdddxxxxxxxxxxxxxxxxxxxxxxxx" +
                            "\noooooooooooooooooc. .lddddddddddddodddddddddddddl. .ldxxxxxxxxxxxxxxxxxxxxxxxxxx" +
                            "\noooooooooooooooooc. 'odddddddddddddddddddddddddd; .:ddddxxxxxxxxxxxxxxxxxxxxxxxx" +
                            "\noooooooooooooooooc. ;odddddddddddolllodddddddddo' ,odddxxxxxxxxxxxxxxxxxxxxxxxxx" +
                            "\noooooooooooooooooc..:ddddddddolc,.....,ldddddddc..cddddxxxxxxxxxxxxxxxxxxxxxxxxx" +
                            "\noooooooooooooooodc..:ddddddddc'        .':dddxo' 'oddxxxxxxxxxxxxxxxxxxxxxxxxxxx" +
                            "\nooooooooooooooooo; .:ddddddo:.           .:dxd:. ,dxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" +
                            "\nooooooooooooooodo' .:dddddo:.             .lxo' .cdddxxxxxxxxxxxxxxxxxxxxxxxxxxx" +
                            "\nooooooooooooodddo, .:odddd:.              .:o'  ,dxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" +
                            "\nooooooooooooodddd:.  .,coo;               .c:  .lxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" +
                            "\noooooooooooddddddoc,.  ..'.               .'. .lxxdddddddddxxxxxxxxxxxxxxxxxxxxx" +
                            "\nooooooooooooddddl;,clc;'.                   .';::,'...'',;:lxxxxxxxxxxxxxxxxxxxx" +
                            "\nooooooooooooddddl,...;looc::,.            .......,;;;:cloodxxxxxxxxxxxxxxxxxxxxx" +
                            "\noooooooooooddddddoc;.....,;:c:.           .  .;odxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" +
                            "\nooooooooooddddddddddoc,......               ':odxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" +
                            "\nooooooooooddddddddddddddoool:.              ....',;codxxxxxxxxxxxxxxxxxxxxxxxxxx" +
                            "\nooooooooooooddddddddolc;;;;'.                 ..    .'lxxxxxxxxxxxxxxxxxxxxxxxxx" +
                            "\noooooooooooodddoc;'...    .               .   ..,,,'. .cdxxxxxxxxxxxxxxxxxxxxxxx" +
                            "\nooooooooooooddc.    ......                 .'.   .;ll. .:dxxxxxxxxxxxxxxxxxxxxxx" +
                            "\noooooooooooddo' .';:;,..   .,,..,.         .;l:..  .''. .lxxxxxxxxxxxxxxxxxxxxxx" +
                            "\noooooooooooddl. .c:.   ..':odo,.cl.         .,lo:,.   ....ldxxxxxxxxxxxxxxxxxxxx" +
                            "\noooooooooddddo'      .,:loddddc..c,    ..':;';odxxoc,. ...'lxxxxxxxxxxxxxxxxxxxx" +
                            "\noooooooooddooo;.  .':oddddddddo:'';,. .;ldxddddxxxxxx:  .'..cxxxxxxxxxxxxxxxxxxx" +
                            "\nooooooooodddodc.  .cdddddddddddddoddolodxxxxxxxxxxxxxo. .c'  ;dxxxxxxxxxxxxxxxxx" +
                            "\nooooooooooddddc.   'ldddddddddxxdddddxxxxxxxxxxxxxxxxd:..co;..cxxxxxxxxxxxxxxxkx" +
                            "\nooooooooodddddl.   .cdddddddddddxxdxxxxxxxxxxxxxxxxxxdl. ;ddc.,dxxxxxxxxxxxxxxxx" +
                            "\nooooooooodddddo:.   ,odddddddxddxxxxxxxxxxxxxxxxxxxxxxd;..lxd;'lkxxxxxxxxxxxxxxx" +
                            "\nooooooooodddddddl;. .,:codddxxxddxxxxxxxxxxxxxxxxxxxxxd:. ;xkdldxxxxxxxxxxxxxxxx" +
                            "\nooooooodooddddddddc. .,;cdxdxxxxxxxxxxxxxxxxxxxxdlcllc;..'lxxxxxxxxxxxxxxxxxxxxx" +
                            "\nooooooddddddddddddo' .:odxdxxxxxxxxxxxxxxxxxxxxxdl::;::coxxxxxxxxxxxxxxxxxxxxxxx" +
                            "\noooooddddddddddddddo:'.';codxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" +
                            "\nooooodddddddddddddddddoc;,,,;:::oxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" +
                            "\noooooooddddddddddddddddxxdolc:;:lxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";

            string result = output.PrintLargeLogo();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [TestCategory("PrintResults")]
        public void PrintResultsWithPopulatedArraysAndNumberTest()
        {
            // TODO: Update test method
            Output output = new Output();
            ArrayList pagesProcessed = new ArrayList
            {
                "https://go.microsoft.com/fwlink/?LinkID=398939",
                "https://go.microsoft.com/fwlink/?LinkID=398600",
                "https://go.microsoft.com/fwlink/?LinkId=699315"
            };
            ArrayList pagesFailed = new ArrayList
            {
                "https://go.microsoft.com/fwlink/?LinkId=699315"
            };
            int numPagesPassed = 2;

            string expected = "Total pages processed: 3\n" +
                                "Total pages passed: 2\n" +
                                "Total pages failed: 1\n" +
                                "Pages failed:\n" +
                                "https://go.microsoft.com/fwlink/?LinkId=699315\n";

            string result = output.PrintResults(pagesProcessed, pagesFailed, numPagesPassed);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [TestCategory("PrintResults")]
        public void PrintResultsWithNullFirstArrayTest()
        {
            // TODO: Update test method
            Output output = new Output();
            ArrayList pagesFailed = new ArrayList
            {
                "https://go.microsoft.com/fwlink/?LinkId=699315"
            };
            int numPagesPassed = 2;

            string expected = "There were no pages to process\n";

            string result = output.PrintResults(null, pagesFailed, numPagesPassed);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [TestCategory("PrintResults")]
        public void PrintResultsWithEmptyFirstArrayTest()
        {
            // TODO: Update test method
            Output output = new Output();
            ArrayList pagesProcessed = new ArrayList();
            ArrayList pagesFailed = new ArrayList
            {
                "https://go.microsoft.com/fwlink/?LinkId=699315"
            };
            int numPagesPassed = 2;

            string expected = "There were no pages to process\n";

            string result = output.PrintResults(pagesProcessed, pagesFailed, numPagesPassed);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [TestCategory("PrintResults")]
        public void PrintResultsWithEmptySecondArrayTest()
        {
            // TODO: Update test method
            Output output = new Output();
            ArrayList pagesProcessed = new ArrayList
            {
                "https://go.microsoft.com/fwlink/?LinkID=398939",
                "https://go.microsoft.com/fwlink/?LinkID=398600"
            };
            ArrayList pagesFailed = new ArrayList();
            int numPagesPassed = 2;

            string expected = "Total pages processed: 2\n" +
                                "Total pages passed: 2\n" +
                                "Total pages failed: 0\n";

            string result = output.PrintResults(pagesProcessed, pagesFailed, numPagesPassed);

            Assert.AreEqual(expected, result);
        }
    }
}
