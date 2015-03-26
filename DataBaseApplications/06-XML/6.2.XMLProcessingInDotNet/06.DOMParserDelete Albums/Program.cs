// Problem 6.	DOM Parser: Delete Albums
// Using the DOM parser write a program to delete from catalog.xml all albums
// having price > 20. Save the result in a new file cheap-albums-catalog.xml.

namespace _06.DOMParserDelete_Albums
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    class Program
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\catalog.xml");

            XmlNodeList nodes = doc.DocumentElement.ChildNodes;
            XmlNodeList childNodes = nodes[0].ChildNodes;

            for (int i = 0; i < childNodes.Count; i++)
            {
                var currentNode = childNodes[i];
                if (decimal.Parse(currentNode["price"].InnerText) > 20M)
                {
                    currentNode.RemoveAll();
                }
            }

            Console.WriteLine("File cheap-albums-catalog.xml was saved!");
            doc.Save(@"..\..\cheap-albums-catalog.xml");
        }
    }
}