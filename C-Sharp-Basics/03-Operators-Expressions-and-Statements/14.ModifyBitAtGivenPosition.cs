using System;

    class ModifyBitAtGivenPosition
    {
        static void Main()
        {
            int number = Int32.Parse(Console.ReadLine());
            int position = Int32.Parse(Console.ReadLine());
            int value = Int32.Parse(Console.ReadLine());
            int result;
            int mask = value << position;
            number = number & (~(1 << position)); // na pozicia p zapisvame 0
            result = number | mask;               // na pozicia p zapisvame stoinostta na v
            Console.WriteLine(result); 
        }
    }
