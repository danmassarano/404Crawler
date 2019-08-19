using System;
using System.Collections;

namespace _404Crawler
{
    /// <summary>
    /// Output class is used for any methods used to print things out into the
    /// console, and handles all formatting and logging.
    /// </summary>
    public class Output
    {
        /// <summary>
        /// Prints header for program: 
        /// Shows the logo and the startpoint URL
        /// </summary>
        /// <param name="startPage"></param>
        internal void PrintHeader(string startPage)
        {
            PrintLogo();
            Console.WriteLine($"Starting crawler from {startPage}");
        }

        /// <summary>
        /// Prints the logo
        /// </summary>
        internal void PrintLogo()
        {
            Console.WriteLine("     |" +
            	            "\n     |" +
            	            "\n     |" +
            	            "\n     |" +
            	            "\n     |" +
            	            "\n  /  |   \\" +
            	            "\n ;_/,L-,\\_;" +
            	            "\n\\._/3  E\\_./" +
            	            "\n\\_./(::)\\._/" +
            	            "\n     ''" +
            	            "\n");
        }

        /// <summary>
        /// Prints the large varsion of the logo
        /// </summary>
        internal void PrintLargeLogo()
        {
            Console.WriteLine("lllloooooooooooooooooooooooooooddddddddddddddddddddddddddddddddddddddddddddddddd" +
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
            	            "\noooooooddddddddddddddddxxdolc:;:lxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
        }

        /// <summary>
        /// Outputs all new links to process found
        /// </summary>
        /// <param name="pagesToProcess"></param>
        internal void PrintNewLinks(ArrayList pagesToProcess)
        {
            Console.WriteLine($"Number of new pages to process : {pagesToProcess.Count}");
            Console.WriteLine($"New links found:");

            foreach (var link in pagesToProcess)
            {
                Console.WriteLine($"{link.ToString()}");
            }
        }

        /// <summary>
        /// Outputs results from crawl, how many pages passed and failed
        /// </summary>
        /// <param name="pagesProcessed"></param>
        /// <param name="pagesFailed"></param>
        /// <param name="numPagesPassed"></param>
        internal void PrintResults(ArrayList pagesProcessed, ArrayList pagesFailed, int numPagesPassed)
        {
            Console.WriteLine($"Total pages processed: {pagesProcessed.Count}");
            Console.WriteLine($"Total pages passed: {numPagesPassed}");
            Console.WriteLine($"Total pages failed: {pagesFailed.Count}");

            foreach (var link in pagesFailed)
            {
                Console.WriteLine($"{link.ToString()}");
            }
        }
    }
}
