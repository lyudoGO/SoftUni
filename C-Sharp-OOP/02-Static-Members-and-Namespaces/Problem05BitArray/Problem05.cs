using Problem05BitArray;
using System;

class Problem05
{
    static void Main(string[] args)
    {
        BitArray number = new BitArray(10);
        number[0] = 1;
        number[3] = 1;
        number[9] = 1;
        Console.Write("Decimal representation of number {0} is: {1}\n", GetBinaryNum(number, 10), number);

        BitArray number1 = new BitArray(9000);
        number1[1] = 1;
        number1[10] = 1;
        number1[11] = 1;
        number1[12] = 1;
        number1[13] = 1;
        number1[1250] = 1;
        number1[8999] = 1;
        Console.WriteLine("Decimal representation of number {0} is: {1}\n", GetBinaryNum(number1, 9000), number1);

        BitArray number2 = new BitArray(8);
        number2[7] = 1;
        Console.WriteLine("Decimal representation of number {0} is: {1}\n", GetBinaryNum(number2, 8), number2);
        // Throw excaption
        number2[7] = 5;
    }
    
    static string GetBinaryNum(BitArray number, int count)
    {
        string result = "";
        for (int i = 0; i < count; i++)
        {
            result += number[i];
        }

        return result;
    }
}