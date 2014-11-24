namespace SquareRootLogSin
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

        static void SquareRoot(dynamic number)
        {
            for (int i = 0; i < 100000; i++)
            {
                Math.Sqrt(number);
            }
        }

        static void NaturalLog(dynamic number)
        {
            for (int i = 0; i < 100000; i++)
            {
                Math.Log(number);
            }
        }

        static void Sinus(dynamic number)
        {
            for (int i = 0; i < 100000; i++)
            {
                Math.Sin(number);
            }
        }

        static void Main()
        {
            float floatNum = 1.0F;
            double doubleNum = 1.0;
            decimal decimalNum = 1M;

            Console.WriteLine("Test square root performance to:");
            DisplayExecutionTime(() => SquareRoot(floatNum), "Float  ");
            DisplayExecutionTime(() => SquareRoot(doubleNum), "Double ");
            DisplayExecutionTime(() => SquareRoot((double)decimalNum), "Decimal");

            Console.WriteLine("\nTest natural log root performance to:");
            DisplayExecutionTime(() => NaturalLog(floatNum), "Float  ");
            DisplayExecutionTime(() => NaturalLog(doubleNum), "Double ");
            DisplayExecutionTime(() => NaturalLog((double)decimalNum), "Decimal");

            Console.WriteLine("\nTest sinus performance to:");
            DisplayExecutionTime(() => Sinus(floatNum), "Float  ");
            DisplayExecutionTime(() => Sinus(doubleNum), "Double ");
            DisplayExecutionTime(() => Sinus((double)decimalNum), "Decimal");
        }
    }
}
