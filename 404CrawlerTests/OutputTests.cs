using _404Crawler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
        public void PrintResultsWithEmptyListTest()
        {
            Output output = new Output();
            string expected = "\nThere were no pages to test\n";

            string result = output.PrintResults(new List<Link>());

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [TestCategory("PrintResults")]
        public void PrintResultsWithNullListTest()
        {
            Output output = new Output();
            string expected = "\nThere were no pages to test\n";

            string result = output.PrintResults(null);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [TestCategory("Online")]
        [TestCategory("PrintResults")]
        public void PrintResultsWithListNoFailuresTest()
        {
            Output output = new Output();
            List<Link> links = new List<Link>
            {
                new Link("https://www.example.com/",
                            "https://www.example.com/",
                            true,
                            true,
                            true)
            };

            string expected = $"\n" +
                                $"Total pages tested : 1\n" +
                                $"Total pages passed : 1\n" +
                                $"Total pages failed : 0\n" +
                                $"Total pages using insecure connection : 1\n" +
                                $"All links good\n" +
                                $"Links using insecure connection:\n" +
                                $"\thttps://www.example.com/ : SSL Certificate is invalid\n";

            string result = output.PrintResults(links);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [TestCategory("Online")]
        [TestCategory("PrintResults")]
        public void PrintResultsWithListContainsFailuresTest()
        {
            Output output = new Output();
            List<Link> links = new List<Link>
            {
                new Link("https://www.example.com/",
                            "https://www.example.com/",
                            false,
                            true,
                            true)
            };

            string expected = $"\n" +
                                $"Total pages tested : 1\n" +
                                $"Total pages passed : 0\n" +
                                $"Total pages failed : 1\n" +
                                $"Total pages using insecure connection : 1\n" +
                                $"Links with broken connection:\n" +
                                $"\thttps://www.example.com/\n" +
                                $"Links using insecure connection:\n" +
                                $"\thttps://www.example.com/ : SSL Certificate is invalid\n";

            string result = output.PrintResults(links);

            Assert.AreEqual(expected, result);
        }
    }
}
