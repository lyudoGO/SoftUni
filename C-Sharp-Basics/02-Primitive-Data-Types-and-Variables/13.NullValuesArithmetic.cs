using System;

class NullValuesArithmetic
{
    static void Main(string[] args)
    {
        char c;
        for (int i = 0; i < 256; i++)
        {
            c = Convert.ToChar(i);
            Console.WriteLine("ASCII character:\t" + c + "\t" + "ASCII number:\t" + i);
        }

    }
}

