using System;

class BitsExchange
{
    static void Main()
    {
        uint number = UInt32.Parse(Console.ReadLine());
        int bitAt3Posision = (int)(number  & (1 << 3));
        int bitAt4Posision = (int)((number >> 4) & 1);
        int bitAt5Posision = (int)((number >> 5) & 1);
        int bitAt24Posision = (int)((number >> 24) & 1);
        int bitAt25Posision = (int)((number >> 25) & 1);
        int bitAt26Posision = (int)((number >> 26) & 1);

        number = number & (~((uint)1 << 3)); 
        number = number | ((uint)bitAt24Posision << 3);
        number = number & (~((uint)1 << 4));
        number = number | ((uint)bitAt25Posision << 4);
        number = number & (~((uint)1 << 5));
        number = number | ((uint)bitAt26Posision << 5);
        number = number & (~((uint)1 << 24));
        number = number | ((uint)bitAt3Posision << 24);
        number = number & (~((uint)1 << 25));
        number = number | ((uint)bitAt4Posision << 25);
        number = number & (~((uint)1 << 26));
        number = number | ((uint)bitAt5Posision << 26);
        Console.WriteLine(number);

    }
}

