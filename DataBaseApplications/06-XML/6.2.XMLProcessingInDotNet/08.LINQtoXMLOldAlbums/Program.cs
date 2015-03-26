// Problem 8.	LINQ to XML: Old Albums
// Write a program, which extract from the file catalog.xml the titles and prices for all albums, 
// published 5 years ago or earlier. Use XDocument and LINQ to XML query.

namespace _08.LINQtoXMLOldAlbums
{
    using System;
    using System.Xml;
    using System.Linq;
    using System.Xml.Linq;

    class Program
    {
        static void Main()
        {
            XDocument doc = XDocument.Load(@"..\..\..\01.MusicalAlbumsXMLFormat\catalog.xml");
            var allAlbums =
                from album in doc.Descendants("album")
                where int.Parse(album.Element("year").Value) >= 2010
                select new
                {
                    Title = album.Element("name").Value,
                    Price = album.Element("price").Value
                };

            foreach (var album in allAlbums)
            {
                Console.WriteLine("Album title: {0}; Price: {1}", album.Title, album.Price);
            }

            // Another examle
            //var allAlbums = doc.Descendants("album").Where(a => int.Parse(a.Element("year").Value) >= 2010);
            //
            //foreach (XElement album in allAlbums)
            //{
            //    string title = album.Element("name").Value;
            //    string price = album.Element("price").Value;
            //    Console.WriteLine("Album title: {0}; Price: {1}", title, price); 
            //}
        }
    }
}
