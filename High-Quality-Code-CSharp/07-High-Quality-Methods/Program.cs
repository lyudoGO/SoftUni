namespace Methods
{
    using System;
    
    public class Program
    {
        static void Main()
        {
            Console.WriteLine(Methods.CalcTriangleArea(3, 4, 5));

            Console.WriteLine(Methods.NumberToWord(5));

            Console.WriteLine(Methods.FindMaxNumber(5, -1, 3, 2, 14, 2, 3));

            Methods.PrintDoubleWithTwoDigit(1.3);
            Methods.PrintDoubleWithPrecent(0.75);
            Methods.PrintDoubleAligned(2.30);

            Console.WriteLine(Methods.CalcDistanceBetweenPoints(3, -1, 3, 2.5));
            Console.WriteLine("Horizontal? " + Methods.IsHorizontalLine(3, -1, 3, 2.5));
            Console.WriteLine("Vertical? " + Methods.IsVerticalLine(3, -1, 3, 2.5));

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
            peter.OtherInfo = "From Sofia, born at 17.03.1992";

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
            stella.OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993";

            Console.WriteLine("{0} older than {1} -> {2}",
                              peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
