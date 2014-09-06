using System;

class BitwiseExtractBit3
{
static void Main()
{
        
    int number = Int32.Parse(Console.ReadLine());
    int mask = 1 << 3;
    int result = number & mask;

    if(result != 0 )
        Console.WriteLine(1);
    else
        Console.WriteLine(0);

}
}

