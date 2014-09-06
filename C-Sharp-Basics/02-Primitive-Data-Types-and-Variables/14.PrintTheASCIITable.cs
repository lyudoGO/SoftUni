using System;

class PrintTheASCIITable
{
    static void Main()
    {
        
        char symbol = (char)0;
        for (int i = 0; i < 255; i++)
        {
            Console.WriteLine("{0} = {1}",i ,symbol);
            symbol++;
        }
    }
}

