// Problem 9.	* XmlWriter: Directory Contents as XML
// Write a program to traverse given directory and write to a XML file its 
// contents together with all subdirectories and files. Use tags <file> and <dir> with attributes. 
// For the generation of the XML document use the class XmlWriter. 

namespace _09.XmlWriterDirectoryContentsXML
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;

    class Program
    {
        static void Main()
        {
            string path = @"..\..\";
            DirectoryInfo dir = new DirectoryInfo(path);

            string lastDir = new DirectoryInfo(dir.FullName).Name;
            string fullPath = dir.FullName.Replace((lastDir + "\\"), "");

            XmlTextWriter writer = new XmlTextWriter(@"..\..\directory-content.xml", Encoding.UTF8);

            using (writer)
            {
                writer.WriteStartDocument();
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;
                writer.WriteStartElement("root-dir");
                writer.WriteAttributeString("path", fullPath);

                CreateXMLContent(writer, dir);

                writer.WriteEndDocument();
                Console.WriteLine("Directory content was saved to directory-content.xml");
            }
        }

        private static void CreateXMLContent(XmlTextWriter writer, DirectoryInfo dir)
        {
            if (dir.GetFiles().Count() == 0 && dir.GetDirectories().Count() == 0)
            {
                return;
            }

            writer.WriteStartElement("dir");
            writer.WriteAttributeString("name", dir.Name);

            foreach (var currentDir in dir.GetDirectories())
            {
                CreateXMLContent(writer, currentDir);
            }
            
            foreach (var file in dir.GetFiles())
            {
                writer.WriteStartElement("file");
                writer.WriteAttributeString("name", file.Name);
                writer.WriteEndElement();
            }
   
            writer.WriteEndElement();
        }
    }
}