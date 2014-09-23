using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Problem01
{
    static void Main(string[] args)
    {
        Console.Write("Enter a integer number: ");
        string input = Console.ReadLine();
        try
        {
            int number = Int32.Parse(input);
            if (number < 0)
            {
                throw new ArithmeticException("Invalid number!Sqrt for negative numbers is undefined!");
            }
            double result = Math.Sqrt(number);
            Console.WriteLine("Square root: " + result);
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Invalid number!You are entering a null!");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid number!You are entering a string!");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Invalid number!You are entering a number bigger than Int32 type!");
        }
        finally
        {
            Console.WriteLine("Good bye");
        }
    }
}