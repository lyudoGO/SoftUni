using System;
using System.Collections.Generic;

namespace Problem03GenericList04Attribute
{
    class Problem03
    {
        static void Main(string[] args)
        {
            GenericList<int> num = new GenericList<int>();
            num.Adding(10);
            num.Adding(2);
            num.Adding(345);
            num.Adding(-34);
            num.Adding(-456);

            Console.WriteLine("\nEntering integer elements: ");
            num.Printing();

            Console.WriteLine("\nMin value: " + num.Min<int>());
            Console.WriteLine("\nMax value: " + num.Max<int>());

            Console.WriteLine("\nElement 345 is at index: " + num.Finding(345));

            num.Removing(3);
            Console.WriteLine("\nRemove the element at position 3 and printing the other elements:");
            num.Printing();

            Console.WriteLine("\n\n\n");

            GenericList<string> str = new GenericList<string>();
            str.Adding("wolf");
            str.Adding("elephant");
            str.Adding("monkey");
            str.Adding("tiger");
            str.Adding("snake");

            Console.WriteLine("Entering string elements: ");
            str.Printing();
            Console.WriteLine("\nMin value: " + str.Min<string>());
            Console.WriteLine("\nMax value: " +  str.Max<string>());
                     
            Console.WriteLine("\nElement \"snake\" is at index: " + str.Finding("snake"));

            str.Removing(3);
            Console.WriteLine("\nRemove the element at position 3 and printing the other elements:");
            str.Printing();
            Console.WriteLine();

            Type type = typeof(GenericList<>);
            object[] allAttributes = type.GetCustomAttributes(typeof(VersionAttribute), false);
            for (int i = allAttributes.Length - 1; i >= 0 ; i--)
            {
                Console.WriteLine("GenericsList have version: {0}", ((VersionAttribute)allAttributes[i]).Version);
            }
        }
    }
}