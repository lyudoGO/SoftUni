// Problem 3.	DOM Parser: Extract All Artists Alphabetically
// Write a program that extracts all artists in alphabetical order from catalog.xml. 
// Use the DOM parser. Keep the artists in a SortedSet<string> 
// to avoid duplicates and to keep the artist in alphabetical order.

namespace _03.DOMParserExtractArtists
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

            XmlNodeList nodes = doc.DocumentElement.ChildNodes;
            XmlNodeList childNodes = nodes[0].ChildNodes;
            SortedSet<string> artists = new SortedSet<string>();

            for (int i = 0; i < childNodes.Count; i++)
            {
                artists.Add(childNodes[i]["artist"].InnerText);
            }

            foreach (var artist in artists)
            {
                Console.WriteLine("Artist name: {0}", artist);
            }
        }
    }
}
