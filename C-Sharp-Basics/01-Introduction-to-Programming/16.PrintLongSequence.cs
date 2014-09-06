using System;

class PrintLongSequence
{
    static void Main()
    {
        int num1 = 2;
        int num2 = -3;
        for (int i = 0; i < 500; i++)
        {

            Console.Write(num1 + " " + num2 + " ");
            num1 = num1 + 2;
            num2 = num2 - 2;
        }
    }
}

