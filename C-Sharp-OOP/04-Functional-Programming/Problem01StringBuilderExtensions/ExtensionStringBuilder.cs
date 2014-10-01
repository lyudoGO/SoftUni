using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Problem01StringBuilderExtensions
{
    public static class ExtensionStringBuilder
    {
        public static StringBuilder Substring(this StringBuilder str, int startIndex, int length)
        {
            StringBuilder sb = new StringBuilder();
            
            if (startIndex < 0 || startIndex >= str.Length)
            {
                throw new ArgumentOutOfRangeException("Start index is out of range [0.." + (str.Length - 1) + "]");
            }
            if (length < 0 || length > str.Length || (startIndex + length) > str.Length)
            {
                throw new ArgumentOutOfRangeException("Length index is out of range [0.." + (str.Length) + "]");
            }
            for (int i = startIndex; i < startIndex + length; i++)
            {
                sb.Append(str[i]);
            }

            return sb;
        }

        public static StringBuilder RemoveText(this StringBuilder str, string text)
        {
            string origStr = str.ToString();
            origStr = Regex.Replace(origStr, text, "", RegexOptions.IgnoreCase);

            str.Clear();
            str.AppendLine(origStr);
            return str;
        }

        public static StringBuilder AppendAll<T>(this StringBuilder str, IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                string strItem = item.ToString();
                str.Append(strItem + " ");
            }

            return str;
        }
    }
}