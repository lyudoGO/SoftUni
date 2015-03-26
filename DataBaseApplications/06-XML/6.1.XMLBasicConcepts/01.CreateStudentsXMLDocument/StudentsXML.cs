// Problem 1.	Create Students XML Document
// Create a XML document students.xml, which contains structured description of students. 
// For each student you should enter information for his name, gender, birth date (in ISO 8601 format), 
// phone number (optional), email, university, specialty, faculty number (optional)
// and a list of taken exams (exam name, date taken, grade).

namespace _01.CreateStudentsXMLDocument
{
    using System;
    using System.Xml;

    class StudentsXML
    {
        static void Main()
        {
            XmlDocument studentsXml = new XmlDocument();
            studentsXml.Load(@"..\..\students.xml");

            System.Console.WriteLine(studentsXml.OuterXml);
        }
    }
}
