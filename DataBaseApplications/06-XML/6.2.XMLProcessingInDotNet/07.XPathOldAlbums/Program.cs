// Problem 7.	DOM Parser and XPath: Old Albums
// Write a program, which extract from the file catalog.xml the titles and prices for all albums, 
// published 5 years ago or earlier. Use XPath query.

namespace _07.XPathOldAlbums
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

            string xPathQuery = "catalog/albums/album[year/text() >= 2010]";
            XmlNodeList nodes = doc.SelectNodes(xPathQuery);

            foreach (XmlElement node in nodes)
            {
                string title = node.SelectSingleNode("name").InnerText;
                string price = node.SelectSingleNode("price").InnerText;

                Console.WriteLine("Album title: {0}; Price: {1}", title, price);
            }
        }
    }
}
