//Problem 10.	XElement: Directory Contents as XML
//Rewrite the previous task (build XML to hold directory contents) with XDocument, 
//XElement and XAttribute.

namespace _10.XElementDirectoryContentsAsXML
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Linq;

    class Program
    {
        static void Main()
        {
            string path = @"..\..\";
            DirectoryInfo dir = new DirectoryInfo(path);

            string lastDir = new DirectoryInfo(dir.FullName).Name;
            string fullPath = dir.FullName.Replace((lastDir + "\\"), "");
            
            XDocument doc = new XDocument(
                new XDeclaration("1.0", "Utf-8", null),
                new XElement("root-dir", new XAttribute("path", fullPath))
            );

            var xElements = CreateXMLContent(dir);
            doc.Root.Add(xElements);

            Console.WriteLine("Directory content was saved to directory-content.xml");
            doc.Save(@"..\..\directory-content.xml");
        }

        private static XElement CreateXMLContent(DirectoryInfo dir)
        {
            var directoryContent = new XElement("dir", new XAttribute("name", dir.Name));
            var directories = dir.GetDirectories().ToList();

            foreach (var directory in directories)
            {
                directoryContent.Add(CreateXMLContent(directory));
            }

            foreach (var file in dir.GetFiles())
            {
                directoryContent.Add(new XElement("file", new XAttribute("name", file.Name)));
            }

            return directoryContent;
        }
    }
}
