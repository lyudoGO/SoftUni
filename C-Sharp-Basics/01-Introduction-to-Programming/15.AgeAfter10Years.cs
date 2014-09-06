using System;

    class AgeAfter10Years
    {
        static void Main()
        {
            int years;
            int yearsAfter10;
            Console.Write("Enter your age: ");
            years = int.Parse(Console.ReadLine());
            yearsAfter10 = years + 10;
            Console.WriteLine("After 10 years you are {0} years old.", yearsAfter10);

        }
    }

