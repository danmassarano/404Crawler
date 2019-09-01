using System;
using System.Collections;
using System.Diagnostics;
using System.Net;
using _404Crawler;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _404CrawlerTests
{
    /// <summary>
    /// Unit tests for Output class, tests that console logs are accurate
    /// </summary>
    [TestClass]
    public class OutputTests
    {
        [TestCategory("PrintHeader")]
        [TestMethod]
        public void PrintHeaderTest()
        {
            Output output = new Output();
            string expected = "Starting crawler from https://www.google.com";

            string result = output.PrintHeader("https://www.google.com");

            Assert.AreEqual(expected, result);
        }

        [TestCategory("PrintHeader")]
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException),
            "null was not specified")]
        public void PrintHeaderNullTest()
        {
            Output output = new Output();

            _ = output.PrintHeader(null);
        }

        [TestCategory("PrintLogo")]
        [TestMethod]
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

        [TestCategory("PrintLogo")]
        [TestMethod]
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

        [TestCategory("PrintNewLinks")]
        [TestMethod]
        public void PrintNewLinksWithPopulatedArrayTest()
        {
            // pass array with links in
            // expect string result
        }

        [TestCategory("PrintNewLinks")]
        [TestMethod]
        public void PrintNewLinksWithEmptyArrayTest()
        {
            // pass array with no links in
            // expect string result with just results = 0
        }

        [TestCategory("PrintNewLinks")]
        [TestMethod]
        public void PrintNewLinksWithNullArrayTest()
        {
            // pass null array
            // expect string result with just results = 0
        }

        [TestCategory("PrintResults")]
        [TestMethod]
        public void PrintResultsWithPopulatedArraysAndNumberTest()
        {
            // pass populated first array
            // pass populated second array
            // pass integer
            // expect string result
        }

        [TestCategory("PrintResults")]
        [TestMethod]
        public void PrintResultsWithNullFirstArrayTest()
        {
            // pass empty first array
            // pass populated second array
            // pass integer
            // expect string result
        }

        [TestCategory("PrintResults")]
        [TestMethod]
        public void PrintResultsWithNullSecondArrayTest()
        {
            // pass populated first array
            // pass empty second array
            // pass integer
            // expect string result - just results
        }
    }
}
