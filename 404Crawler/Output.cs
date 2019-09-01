using System;
using System.Collections;

namespace _404Crawler
{
    /// <summary>
    /// Output class is used for any methods used to print things out into the
    /// console, and handles all formatting and logging.
    /// </summary>Prints header for program
    public class Output
    {
        /// <summary>
        /// Prints header for program
        /// </summary>
        /// <param name="startPage"></param>
        /// <exception cref="System.ArgumentNullException">Thrown when a null string is passwed as a URL</exception>
        /// <returns>Header for program</returns>
        public string PrintHeader(string startPage)
        {
            if (string.IsNullOrEmpty(startPage))
            {
                throw new ArgumentNullException($"{nameof(startPage)} was not specified");
            }

            return $"Starting crawler from {startPage}";
        }

        /// <summary>
        /// String of the logo
        /// </summary>
        /// <returns>String of the logo</returns>
        public string PrintLogo()
        {
            return "     |" +
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
        }

        /// <summary>
        /// String of large version of the logo
        /// </summary>
        /// <returns>String of large version of the logo</returns>
        public string PrintLargeLogo()
        {
            return("lllloooooooooooooooooooooooooooddddddddddddddddddddddddddddddddddddddddddddddddd" +
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
        /// <returns>A formatted string to print new links</returns>
        public string PrintNewLinks(ArrayList pagesToProcess)
        {
            if (pagesToProcess == null || pagesToProcess.Count == 0)
            {
                return "Number of new pages to process : 0\n";
            }

            string result = "";
            result += $"Number of new pages to process : {pagesToProcess.Count}\n";
            result += $"New links found:\n";

            foreach (var link in pagesToProcess)
            {
                result += $"{link.ToString()}\n";
            }

            return result;
        }

        /// <summary>
        /// Builds string to print results from crawl.
        /// Shows how many pages passed and failed
        /// </summary>
        /// <param name="pagesProcessed"></param>
        /// <param name="pagesFailed"></param>
        /// <param name="numPagesPassed"></param>
        /// <returns>A formatted string to print results</returns>
        public string PrintResults(ArrayList pagesProcessed, ArrayList pagesFailed, int numPagesPassed)
        {            
            if (pagesProcessed == null || pagesProcessed.Count == 0)
            {
                return "There were no pages to process";
            }

            string result = "";
            result += $"Total pages processed: {pagesProcessed.Count}\n";
            result += $"Total pages passed: {numPagesPassed}\n";
            result += $"Total pages failed: {pagesFailed.Count}\n";

            if (pagesFailed.Count > 0)
            {
                result += "Pages failed:\n";

                foreach (var link in pagesFailed)
                {
                    result += $"{link.ToString()}\n";
                }
            }

            return result;
        }
    }
}
