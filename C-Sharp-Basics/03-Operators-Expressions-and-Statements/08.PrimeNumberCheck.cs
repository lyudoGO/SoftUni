using System;

class PrimeNumberCheck
{
    static void Main()
    {
        int number = Int32.Parse(Console.ReadLine());
        bool isPrime = true;

        if (number <= 1)
        {
            isPrime = false;
            
        }    
        else
        {
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                bool isDivideble = (number % i) == 0;
                if (isDivideble)
                {
                    isPrime = false;
                    break;
                }
            }
        }
        Console.WriteLine(isPrime);
    }
}

