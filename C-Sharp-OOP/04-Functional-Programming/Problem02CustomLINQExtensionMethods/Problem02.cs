using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem02CustomLINQExtensionMethods
{
    class Problem02
    {
        static void Main(string[] args)
        {
            IEnumerable<string> collections = new List<string>()
            {
                "Sofia", "Varna", "Plovdiv", "Burgas", "V.Tyrnovo", "Vidin", "Durankulak"
            };

            var notCollections = collections.WhereNot<string>(x => x.Contains("Sofia"));
            PrintCollections(notCollections);

            var reapetCollections = collections.Repeat<string>(2);
            PrintCollections(reapetCollections);

            var filterCollections = collections.WhereEndsWith<string>(new List<string>() {"a", "k"});
            PrintCollections(filterCollections);
        }

        public static void PrintCollections(IEnumerable collections)
        {
            foreach (var item in collections)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
    }
}