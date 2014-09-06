using System;
using System.Text;


class IsoscelesTriangle
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        char symbol = '\u00a9';
        
        Console.WriteLine("   {0}   ", symbol);
        Console.WriteLine("  {0} {0}  ", symbol);
        Console.WriteLine(" {0}   {0}", symbol);
        Console.WriteLine("{0} {0} {0} {0}  ", symbol);
        
    }
}

