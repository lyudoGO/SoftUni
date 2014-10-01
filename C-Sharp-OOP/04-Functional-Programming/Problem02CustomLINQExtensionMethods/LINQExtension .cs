using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem02CustomLINQExtensionMethods
{
    public static class LINQExtension
    {
        public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            var result = collection.Where(item => !predicate(item));
            return result;
        }

        public static IEnumerable<T> Repeat<T>(this IEnumerable<T> collection, int count)
        {
            IEnumerable<T> result = Enumerable.Empty<T>();
            if (count == 0)
            {
                return result;
            }
            else 
            {
                for (int i = 0; i < count; i++)
                {
                    result = result.Concat(collection);
                }
            }

            return result;
        }

        public static IEnumerable<string> WhereEndsWith<T>(this IEnumerable<string> collection, IEnumerable<string> suffixes)
        {
            List<string> stringList = new List<string>();
            foreach (var str in collection)
            {
                foreach (var suffix in suffixes)
                {
                    if (str.EndsWith(suffix))
                    {
                        stringList.Add(str);
                    }
                }
            }
            IEnumerable<string> result = stringList.AsEnumerable();
            return result;
        }
    }
}