namespace Methods
{
    using System;

    public class Methods
    {
        public static double CalcTriangleArea(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new ArgumentOutOfRangeException("Sides should be positive and bigger than zero!");
            }

            double halfPerimeter = (sideA + sideB + sideC) / 2;
            double area = Math.Sqrt(halfPerimeter * (halfPerimeter - sideA) * (halfPerimeter - sideB) * (halfPerimeter - sideC));

            return area;
        }

        public static string NumberToWord(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: throw new ArgumentOutOfRangeException("Invalid number.Must be integer in range [0...9]!");
            }
        }

        public static int FindMaxNumber(params int[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException("Array of elements cannot be null!");
            }

            if (elements.Length == 0)
            {
                throw new ArgumentException("No elements specified!");
            }

            int maxElement = 0;
            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > maxElement)
                {
                    maxElement = elements[i];
                }
            }

            return maxElement;
        }

        public static void PrintDoubleWithTwoDigit(double number)
        {
              Console.WriteLine("{0:f2}", number);
        }

        public static void PrintDoubleWithPrecent(double number)
        {
            Console.WriteLine("{0:p0}", number);
        }

        public static void PrintDoubleAligned(double number)
        {
            Console.WriteLine("{0,8}", number);
        }

        public static double CalcDistanceBetweenPoints(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        public static bool IsHorizontalLine(double x1, double y1, double x2, double y2)
        {
            if (x1 == x2 && y1 == y2)
            {
                throw new ArgumentException("A line cannot be define by single point!");
            }

            return y1 == y2;
        }

        public static bool IsVerticalLine(double x1, double y1, double x2, double y2)
        {
            if (x1 == x2 && y1 == y2)
            {
                throw new ArgumentException("A line cannot be define by single point!");
            }

            return x1 == x2;
        }
    }
}
