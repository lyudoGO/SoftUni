namespace AddSubtractIncrement
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Diagnostics;

    public class Program
    {
        static void DisplayExecutionTime(Action action, string typeName)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            action();
            stopwatch.Stop();
            Console.WriteLine(typeName + "-> " + stopwatch.Elapsed);
        }

        static void Add(dynamic number)
        {
            for (int i = 0; i < 100000; i++)
            {
                number += 10;
            }
        }

        static void Subtract(dynamic number)
        {
            for (int i = 0; i < 100000; i++)
            {
                number -= number;
            }
        }

        static void Increment(dynamic number)
        {
            for (int i = 0; i < 100000; i++)
            {
                number += 1;
            }
        }

        static void Multiply(dynamic number)
        {
            for (int i = 0; i < 100000; i++)
            {
                number *= number;
            }
        }

        static void Divide(dynamic number)
        {
            for (int i = 0; i < 100000; i++)
            {
                number /= number;
            }
        }

        static void Main()
        {
            int intNum = 1;
            long longNum = 1L;
            float floatNum = 1.0F;
            double doubleNum = 1.0;
            decimal decimalNum = 1M;

            Console.WriteLine("Test add performance to:"); 
            DisplayExecutionTime(() => Add(intNum), "Int    ");
            DisplayExecutionTime(() => Add(longNum), "Long   ");
            DisplayExecutionTime(() => Add(floatNum), "Float  ");
            DisplayExecutionTime(() => Add(doubleNum), "Double ");
            DisplayExecutionTime(() => Add(decimalNum), "Decimal");

            Console.WriteLine("\nTest subtract performance to:");
            DisplayExecutionTime(() => Subtract(intNum), "Int    ");
            DisplayExecutionTime(() => Subtract(longNum), "Long   ");
            DisplayExecutionTime(() => Subtract(floatNum), "Float  ");
            DisplayExecutionTime(() => Subtract(doubleNum), "Double ");
            DisplayExecutionTime(() => Subtract(decimalNum), "Decimal");

            Console.WriteLine("\nTest increment performance to:");
            DisplayExecutionTime(() => Increment(intNum), "Int    ");
            DisplayExecutionTime(() => Increment(longNum), "Long   ");
            DisplayExecutionTime(() => Increment(floatNum), "Float  ");
            DisplayExecutionTime(() => Increment(doubleNum), "Double ");
            DisplayExecutionTime(() => Increment(decimalNum), "Decimal");

            Console.WriteLine("\nTest multiply performance to:");
            DisplayExecutionTime(() => Multiply(intNum), "Int    ");
            DisplayExecutionTime(() => Multiply(longNum), "Long   ");
            DisplayExecutionTime(() => Multiply(floatNum), "Float  ");
            DisplayExecutionTime(() => Multiply(doubleNum), "Double ");
            DisplayExecutionTime(() => Multiply(decimalNum), "Decimal");

            Console.WriteLine("\nTest divide performance to:");
            DisplayExecutionTime(() => Divide(intNum), "Int    ");
            DisplayExecutionTime(() => Divide(longNum), "Long   ");
            DisplayExecutionTime(() => Divide(floatNum), "Float  ");
            DisplayExecutionTime(() => Divide(doubleNum), "Double ");
            DisplayExecutionTime(() => Divide(decimalNum), "Decimal");
        }
    }
}