using System;
using System.Collections.Generic;
using System.Text;

namespace basicWebScraper
{
    partial class Program
    {
        static void Main(string[] args)
        {
            // Show header
            showHeader();

            // Scrap!
            //WebScraper.scrapTitlesOnly();
            //WebScraper.scrapTitlesWithTime();
            WebScraper.scrapTitlesWithTime();
        }
    }
}
