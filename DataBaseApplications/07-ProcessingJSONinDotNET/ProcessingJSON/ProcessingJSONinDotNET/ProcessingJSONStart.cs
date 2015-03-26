// Problem 1.	Download the content of the SoftUni RSS feed
// SoftUni RSS Feed: https://softuni.bg/Feed/News
// Your task is to download SoftUni RSS feed programmatically. You can use WebClient.DownloadFile().
// Problem 2. Parse the XML from the feed to JSON
// Problem 3. Using LINQ-to-JSON select all the question titles and print them to the console
// Problem 4. Parse the JSON string to POCO
// Problem 5. Using the parsed objects create a HTML page that lists all questions from the RSS their categories
// and a link to the question’s page

namespace ProcessingJSONinDotNET
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Net;
    using System.Xml;
    using System.Xml.Linq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.IO;
    using System.Collections.Generic;


    class ProcessingJSONStart
    {
        static void Main()
        {
            WebClient webClient = new WebClient();
            webClient.DownloadFile("https://softuni.bg/Feed/News", @"..\..\softuni-rss.json");

            Console.WriteLine("RSS News was downloaded to softuni-rss.json");

            XmlDocument doc = new XmlDocument();
            doc.Load(@"..\..\softuni-rss.json");

            // Problem 2
            var json = JsonConvert.SerializeXmlNode(doc);
            Console.WriteLine(json);
            Console.WriteLine();

            // Problem 3
            SelectAllQuestion(json);

            // Problem 4
            var items = ParseJSONToPOCO(json);

            // Problem 5
            CreateHTMLPage(items);

        }

        private static void CreateHTMLPage(List<Item> items)
        {
            string fileName = @"..\..\questions.html";
            using (XmlTextWriter writer = new XmlTextWriter(fileName, Encoding.UTF8))
            {
                writer.Formatting = System.Xml.Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("html");
                writer.WriteStartElement("head");
                writer.WriteElementString("title", "RSS info");
                writer.WriteEndElement();

                writer.WriteStartElement("body");
                writer.WriteElementString("h2", "SoftUni RSS");
                writer.WriteStartElement("ul");
                foreach (var item in items)
                {
                    writer.WriteStartElement("li");
                    writer.WriteStartElement("a");
                    writer.WriteAttributeString("href", item.Link);
                    writer.WriteElementString("strong", item.Title);
                    writer.WriteEndElement();
                    writer.WriteElementString("span", "Updated: " + item.UpdatedDate.ToString("MM/dd/yyyy H:mm:ss"));
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndElement();

                writer.WriteEndDocument();
            }

            Console.WriteLine("HTML file was created and saved to questions.html\n");
        }

        private static List<Item> ParseJSONToPOCO(string json)
        {
            var jsonObject = JObject.Parse(json);
            var items = jsonObject["rss"]["channel"]["item"].ToList();
            var pocoObjects = new List<Item>();

            foreach (JToken item in items)
            {
                var deserializedObject = JsonConvert.DeserializeObject<Item>(item.ToString());
                pocoObjects.Add(deserializedObject);
            }

            return pocoObjects;
        }

        private static void SelectAllQuestion(string json)
        {
            var jsonObject = JObject.Parse(json);
            var titles = jsonObject["rss"]["channel"]["item"].Select(t => t["title"]).ToList();
            foreach (var title in titles)
            {
                Console.WriteLine(title);
            }
            Console.WriteLine();
        }
    }
}
