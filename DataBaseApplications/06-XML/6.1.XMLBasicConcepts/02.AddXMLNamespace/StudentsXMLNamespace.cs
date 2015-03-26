// Problem 2.	Add XML Namespace
// Explore http://en.wikipedia.org/wiki/ Uniform_Resource_Identifier  to learn more about URI, 
// URN and URL definitions. Add default namespace for the students "urn:students".

namespace _02.AddXMLNamespace
{
    using System;
    using System.Xml;

    class StudentsXMLNamespace
    {
        static void Main()
        {
            XmlDocument studentsXml = new XmlDocument();
            studentsXml.Load(@"..\..\students.xml");

            System.Console.WriteLine(studentsXml.OuterXml);
        }
    }
}
