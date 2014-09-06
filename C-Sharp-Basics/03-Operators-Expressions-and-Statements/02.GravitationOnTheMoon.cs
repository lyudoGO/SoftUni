using System;

class GravitationOnTheMoon
{
    static void Main()
    {
        double weightMan = double.Parse(Console.ReadLine());
        double weightManOnMoon = 0.17 * weightMan;
        Console.WriteLine(weightManOnMoon);
    }
}

