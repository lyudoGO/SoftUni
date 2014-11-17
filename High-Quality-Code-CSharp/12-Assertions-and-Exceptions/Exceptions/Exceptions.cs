using System;
using System.Collections.Generic;
using System.Text;

public class Exceptions
{
    public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
    {
        if (startIndex < 0)
        {
            throw new ArgumentOutOfRangeException("Start index cannot be negative.");
        }

        if (startIndex >= arr.Length)
        {
            throw new ArgumentOutOfRangeException("Start index cannot be bigger than array length.");
        }

        if (count < 0 || count > arr.Length)
        {
            throw new ArgumentOutOfRangeException("The count cannot be negative or bigger than array length.");
        }

        List<T> result = new List<T>();
        for (int i = startIndex; i < startIndex + count; i++)
        {
            result.Add(arr[i]);
        }

        return result.ToArray();
    }

    public static string ExtractEnding(string str, int count)
    {
        if (count < 0)
        {
            throw new ArgumentOutOfRangeException("The count cannot be negative.");
        }

        if (count > str.Length)
        {
            throw new ArgumentOutOfRangeException("The count cannot be bigger than string length.");
        }

        StringBuilder result = new StringBuilder();
        for (int i = str.Length - count; i < str.Length; i++)
        {
            result.Append(str[i]);
        }

        return result.ToString();
    }

    public static void CheckPrime(int number)
    {
        for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
        {
            if (number % divisor == 0)
            {
                Console.WriteLine("The number {0} is not prime!", number);
                return;
            }
        }

        Console.WriteLine("The number {0} is prime!", number);
    }

    static void Main()
    {
        try
        {
            var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
            Console.WriteLine(substr);

            var subarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
            Console.WriteLine(String.Join(" ", subarr));

            var allarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
            Console.WriteLine(String.Join(" ", allarr));

            var emptyarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
            Console.WriteLine(String.Join(" ", emptyarr));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine();

        try
        {
            Console.WriteLine(ExtractEnding("I love C#", 2));
            Console.WriteLine(ExtractEnding("Nakov", 4));
            Console.WriteLine(ExtractEnding("beer", 4));
            Console.WriteLine(ExtractEnding("Hi", 100));

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine();

        try
        {
            CheckPrime(23);
            CheckPrime(33);
            Console.WriteLine();

            List<Exam> peterExams = new List<Exam>()
            {
                new SimpleMathExam(2),
                new CSharpExam(55),
                new CSharpExam(100),
                new SimpleMathExam(1),
                new CSharpExam(0),
            };
           
            Student peter = new Student("Peter", "Petrov", peterExams);
            double peterAverageResult = peter.CalcAverageExamResultInPercents();
            Console.WriteLine("Average results of {0} is {1:p0}", peter.FirstName, peterAverageResult);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
