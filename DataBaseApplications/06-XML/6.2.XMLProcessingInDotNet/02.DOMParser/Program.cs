// Problem 2.	DOM Parser: Extract Album Names
// Write a program that extracts all album names from catalog.xml. Use the DOM parser.

namespace _02.DOMParserExtractAlbumsName
{
    using System;
    using System.Xml;

    class Program
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\..\01.MusicalAlbumsXMLFormat\catalog.xml");
            XmlNodeList nodes = doc.DocumentElement.ChildNodes;
            XmlNodeList childNodes = nodes[0].ChildNodes;

            for (int i = 0; i < childNodes.Count; i++)
            {
                Console.WriteLine("Album name: {0}", childNodes[i]["name"].InnerText);
            }
        }
    }
}