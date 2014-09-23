using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Problem02
{
    static void Main(string[] args)
    {
        int[] numbers = new int[10];
        int index = 0;

        Console.WriteLine("Enter ten numbers in range [1...100], such that 1 < a1 < . . . < a10 < 100");
        while (index < 10)
        {
            Console.Write("Enter a number on index[{0}]: ", index);
            int number = ReadNumber(1, 100);

            if (index == 0)
            {
                numbers[index] = NotEqualTo1or100(number, index);
            }
            else
            {
                numbers[index] = NotEqualTo1or100(number, index);
                if (numbers[index - 1] >= numbers[index])
                {
                    while (numbers[index - 1] >= numbers[index])
                    {
                        Console.WriteLine("Number of index[{0}] must bigger than on index[{1}]!", index, index - 1);
                        Console.Write("Enter a number on index[{0}]: ", index);
                        numbers[index] = ReadNumber(1, 100);
                        if (numbers[index] == 1 || numbers[index] == 100)
                        {
                            numbers[index] = NotEqualTo1or100(number, index);
                        }
                    }
                 }
             }

            index++;
        }

        foreach (int number in numbers)
        {
            Console.WriteLine(number); 
        }
    }

    public static int ReadNumber(int start, int end)
    {
        string input = Console.ReadLine();
        int number = 0;
        try
        {
            number = Int32.Parse(input);
            if (number < 1 || number > 100)
            {
                throw new ArgumentOutOfRangeException("The number is out of range [1...100]!");
            }
           
        }
        catch (FormatException)
        {
            Console.Error.WriteLine("You must enter number, not a text!");
        }
    
        return number;
    }

    public static int NotEqualTo1or100(int number, int index)
    {
        while (number == 1 || number == 100)
        {
            Console.WriteLine("Number must not equal to 1 or 100!");
            Console.Write("Enter a number on index[{0}]: ", index);
            number = ReadNumber(1, 100);
        }

        return number;
    }
}