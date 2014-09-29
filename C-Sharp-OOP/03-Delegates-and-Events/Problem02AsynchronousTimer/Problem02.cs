using System;
using System.Threading;
using System.Threading.Tasks;

namespace Problem02AsynchronousTimer
{
    class Problem02
    {
        public static void Main(string[] args)
        {
            AsyncTimer timer1 = new AsyncTimer(FirstMethod, 300, 30);
            AsyncTimer timer2 = new AsyncTimer(SecondMethod, 600, 20);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("I am the Main() method!Run on every 900ms!");
                Thread.Sleep(900);
            }
        }

        public static void FirstMethod(string str)
        {
            Console.WriteLine("I am the first method!Run on every 300ms!");
        }

        public static void SecondMethod(string str)
        {
            Console.WriteLine("I am the second method!Run on every 600ms!");
        }
    }
}