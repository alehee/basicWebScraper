using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

using HtmlAgilityPack;

namespace basicWebScraper
{
    static class WebScraper
    {
        private static string url = @"https://lowcygier.pl";

        public static void scrapTitlesOnly()
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load(url);

            var searched = document.DocumentNode.SelectNodes("//*[@class='post-title']"); // Notation: //element_name[@with_id_or_class]

            foreach (var node in searched)
            {
                Console.WriteLine(node.InnerText.TrimStart());
            }
        }

        public static void scrapTitlesWithTime()
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load(url);

            var nodes = document.DocumentNode.SelectNodes("//main//div[@class='nc-main']");

            for (int i = 0; i < nodes.Count; i++)
            {
                string title = "";
                string time = "";

                foreach (HtmlNode hn in nodes[i].ChildNodes)
                {
                    if (hn.Name == "header")
                        title = hn.ChildNodes["h2"].InnerText.TrimStart();

                    foreach (string cl in hn.GetClasses())
                    {
                        if (cl == "nc-submeta")
                        {
                            var timeago = hn.SelectNodes(".//time");
                            if (timeago.Count > 0)
                                time = timeago[0].Attributes["title"].Value;
                        }
                    }
                }
                if (title != "" && time != "")
                    Console.WriteLine(time + "\n" + title);
            }
        }
    }
}
