using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem01StringBuilderExtensions
{
    class Problem01
    {
        static void Main(string[] args)
        {
            StringBuilder text1 = new StringBuilder("This method get substring from specified string.");
            StringBuilder text2 = text1.Substring(5, 6);
            Console.WriteLine(text1); 
            Console.WriteLine(text2 + "\n ");

            StringBuilder text3 = new StringBuilder("Remove, remOvE, remOVE all occurrences of a specified string.");
            Console.WriteLine(text3);
            Console.WriteLine(text3.RemoveText("ove"));

            StringBuilder text4 = new StringBuilder("Appends the string representations from the specified collection.");
            Console.WriteLine(text4);
            int[] nums = new int[] {12, 13, 14, 999 };
            Console.WriteLine(text4.AppendAll<int>(nums));
        }
    }
}
