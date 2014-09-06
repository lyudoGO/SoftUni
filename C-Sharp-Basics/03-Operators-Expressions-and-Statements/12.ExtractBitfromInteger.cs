using System;

    class ExtractBitfromInteger
    {
        static void Main()
        {
            int number = Int32.Parse(Console.ReadLine());
            int position = Int32.Parse(Console.ReadLine());
            int mask = 1 << position;
            int bitAtPosition = number & mask;

            if (bitAtPosition != 0)
            {
                Console.WriteLine(1);
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }

