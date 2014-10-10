using System;

namespace Problem02StringDisperser
{
    class Problem02
    {
        static void Main()
        {
            StringDisperser strDisperserOne = new StringDisperser("gosho", "pesho", "kiro", "vlado");
            StringDisperser strDisperserTwo = new StringDisperser("gosho", "pesho23", "kiro", "vlado");

            StringDisperser strDisperserOneClone = strDisperserOne.Clone();

            strDisperserOneClone.Parameters[0] = "cloned";

            Console.WriteLine("Disperser one: {0}", strDisperserOne);
            Console.WriteLine("Disperser one cloned and changed: {0}", strDisperserOneClone);
            Console.WriteLine("Compare Disperser one and Disperser two: {0}", strDisperserOne.CompareTo(strDisperserTwo));

            Console.WriteLine("\nForeach to Disperser one: ");
            foreach (var ch in strDisperserOne)
            {
                Console.Write(ch + " ");
            }
        }
    }
}