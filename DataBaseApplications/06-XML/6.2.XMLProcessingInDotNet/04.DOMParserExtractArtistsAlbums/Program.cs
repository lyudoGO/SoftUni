// Problem 4.	DOM Parser: Extract Artists and Number of Albums
// Write a program that extracts all different artists, which are found in the catalog.xml. 
// For each artist print the number of albums in the catalogue. 
// Use the DOM parser and a Dictionary<string, int> 
// (use the artist name as key and the number of albums as value in the dictionary).

namespace _04.DOMParserExtractArtistsAlbums
{
    using System;
    using System.Xml;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\..\01.MusicalAlbumsXMLFormat\catalog.xml");

            XmlNodeList nodes = doc.DocumentElement.ChildNodes;
            XmlNodeList childNodes = nodes[0].ChildNodes;
            Dictionary<string, int> artists = new Dictionary<string, int>();

            int count = 0;
            for (int i = 0; i < childNodes.Count; i++)
            {
                var currentArtist = childNodes[i]["artist"].InnerText;
                if (!artists.TryGetValue(currentArtist, out count))
                {
                    artists.Add(currentArtist, 1);
                }
                else
                {
                    artists[currentArtist] = count + 1;
                }
            }

            foreach (var artist in artists)
            {
                Console.WriteLine("Artist name: {0}; album numbers: {1}", artist.Key, artist.Value);
            }
        }
    }
}
