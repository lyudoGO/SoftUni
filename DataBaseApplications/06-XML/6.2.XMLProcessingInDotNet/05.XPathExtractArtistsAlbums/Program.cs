// Problem 5.	XPath: Extract Artists and Number of Albums
// Implement the previous using XPath.

namespace _05.XPathExtractArtistsAlbums
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    class Program
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\..\01.MusicalAlbumsXMLFormat\catalog.xml");

            XmlNodeList nodes = doc.SelectNodes("catalog/albums/album/artist");
            Dictionary<string, int> artists = new Dictionary<string, int>();

            int count = 0;

            foreach (XmlElement node in nodes)
            {
                var cuurentNode = node.InnerText;
                if (!artists.TryGetValue(cuurentNode, out count))
                {
                    artists.Add(cuurentNode, 1);
                }
                else
                {
                    artists[cuurentNode] = count + 1;
                }
            }

            foreach (var artist in artists)
            {
                Console.WriteLine("Artist name: {0}; album numbers: {1}", artist.Key, artist.Value);
            }
        }
    }
}
