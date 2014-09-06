using System;

    class CheckBitAtGivenPosition
    {
        static void Main()
        {
            int number = Int32.Parse(Console.ReadLine());
            int position = Int32.Parse(Console.ReadLine());
            int mask = 1 << position;
            int bitAtPosition = number & mask;

            Console.WriteLine((bitAtPosition >> position) == 1 ? true : false);
                
        }
    }

