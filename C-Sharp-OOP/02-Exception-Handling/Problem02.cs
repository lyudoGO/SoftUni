using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Problem02
{
        public static void Main()
        {
            int[] numbers = new int[10];
            int index = 0;
            int start = 1;
            int end = 100;

            Console.WriteLine("Enter ten numbers in range [1...100], such that 1 < a1 < . . . < a10 < 100\n");
            while (index < 10)
            {
                try
                {
                    Console.Write("Enter a number on index[{0}]: ", index);
                    numbers[index] = ReadNumber(start, end);
                    if (index > 0)
                    {
                        if (numbers[index] <= numbers[index - 1])
                        {
                            throw new ArgumentException("Number of index[" + index + "] must bigger than on index[" + (index - 1) + "]!");
                        }
                     }
                    index++;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine("{0}Enter again!", ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("{0}Enter a bigger number!", ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("{0}Enter a valid number!", ex.Message);
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine("{0}Enter number again!", ex.Message);
                }
            }

            Console.WriteLine();
            Console.WriteLine("You entered a range of numbers: ");
            foreach (int num in numbers)
            {
                Console.Write(num + ", ");
            }
        }

        public static int ReadNumber(int start, int end)
        {
            string input = Console.ReadLine();
            int number = Int32.Parse(input);
            if (number <= start || number >= end)
            {
                throw new ArgumentOutOfRangeException("The number is out of range [1...100]!");
            }

           return number;
        }
}


