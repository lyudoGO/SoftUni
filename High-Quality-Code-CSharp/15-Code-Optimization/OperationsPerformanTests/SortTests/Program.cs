namespace SortTests
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

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

        static void InsertionSort<T>(T[] arr) where T : IComparable
        {
            for (int i = 0; i < arr.Length; i++)
            {
                var minElemnet = arr[i];
                int j;
                for (j = i - 1; j >= 0; j--) 
                {
                    if (arr[j].CompareTo(minElemnet) <= 0)
                    {
                        break;
                    }
                    arr[j + 1] = arr[j];
                }
                arr[j + 1] = minElemnet;
            }
        }

        static void SelectionSort<T>(T[] arr) where T : IComparable
        {
            for (int i = 0; i <= arr.Length - 2; i++)
            {
                var minElemnet = arr[i];
                int k = i;
                for (int j = i + 1; j <=  arr.Length - 1; j++)
                {
                    if (arr[j].CompareTo(minElemnet) < 0)
                    {
                        minElemnet = arr[j];
                        k = j;
                    } 
                }
                var currentElement = arr[i];
                arr[i] = arr[k];
                arr[k] = currentElement;
            }
        }

        static void QuickSort<T>(T[] arr, int leftIndex, int rightIndex) where T : IComparable
        {
            int leftPointer = leftIndex;
            int rightPointer = rightIndex;

            IComparable pivot = arr[(leftIndex + rightIndex) / 2];

            while (leftPointer <= rightPointer)
            {
                while (arr[leftPointer].CompareTo(pivot) < 0)
                {
                    leftPointer++;
                }

                while (arr[rightPointer].CompareTo(pivot) > 0)
                {
                    rightPointer--;
                }

                if (leftPointer <= rightPointer)
                {
                    var swap = arr[leftPointer];
                    arr[leftPointer] = arr[rightPointer];
                    arr[rightPointer] = swap;

                    leftPointer++;
                    rightPointer--;
                }
            }

            if (leftIndex < rightPointer)
            {
                QuickSort(arr, leftIndex, rightPointer);
            }

            if (leftPointer < rightIndex)
            {
                QuickSort(arr, leftPointer, rightIndex);
            }
        }

        static void Main()
        {
            int[] integers = new int[5000];
            double[] doubles = new double[5000];
            string[] strings = new string[5000];

            FillArrayDouble(doubles);
            FillArrayInt(integers);
            FillArrayString(strings);
            Console.WriteLine("Selection sort:");
            DisplayExecutionTime(() => SelectionSort(integers), "Int array    ");
            DisplayExecutionTime(() => SelectionSort(doubles), "Double array ");
            DisplayExecutionTime(() => SelectionSort(strings), "String array ");

            FillArrayDouble(doubles);
            FillArrayInt(integers);
            FillArrayString(strings);
            Console.WriteLine("\nInsertion  sort:");
            DisplayExecutionTime(() => InsertionSort(integers), "Int array    ");
            DisplayExecutionTime(() => InsertionSort(doubles), "Double array ");
            DisplayExecutionTime(() => InsertionSort(strings), "String array ");

            FillArrayDouble(doubles);
            FillArrayInt(integers);
            FillArrayString(strings);
            Console.WriteLine("\nQuick  sort:");
            DisplayExecutionTime(() => QuickSort(integers, 0, integers.Length - 1), "Int array    ");
            DisplayExecutionTime(() => QuickSort(doubles, 0, doubles.Length - 1), "Double array ");
            DisplayExecutionTime(() => QuickSort(strings, 0, strings.Length - 1), "String array ");

            Console.WriteLine("\nSelection sort, sorted values:");
            DisplayExecutionTime(() => SelectionSort(integers), "Int array    ");
            DisplayExecutionTime(() => SelectionSort(doubles), "Double array ");
            DisplayExecutionTime(() => SelectionSort(strings), "String array ");

            Console.WriteLine("\nInsertion  sort, sorted values:");
            DisplayExecutionTime(() => InsertionSort(integers), "Int array    ");
            DisplayExecutionTime(() => InsertionSort(doubles), "Double array ");
            DisplayExecutionTime(() => InsertionSort(strings), "String array ");

            Console.WriteLine("\nQuick  sort, sorted values:");
            DisplayExecutionTime(() => QuickSort(integers, 0, integers.Length - 1), "Int array    ");
            DisplayExecutionTime(() => QuickSort(doubles, 0, doubles.Length - 1), "Double array ");
            DisplayExecutionTime(() => QuickSort(strings, 0, strings.Length - 1), "String array ");

            FillRandomArrayDouble(doubles);
            FillRandomArrayInt(integers);
            FillRandomArrayString(strings);
            Console.WriteLine("\nSelection sort, random values:");
            DisplayExecutionTime(() => SelectionSort(integers), "Int array    ");
            DisplayExecutionTime(() => SelectionSort(doubles), "Double array ");
            DisplayExecutionTime(() => SelectionSort(strings), "String array ");

            Console.WriteLine("\nInsertion  sort, random values:");
            DisplayExecutionTime(() => InsertionSort(integers), "Int array    ");
            DisplayExecutionTime(() => InsertionSort(doubles), "Double array ");
            DisplayExecutionTime(() => InsertionSort(strings), "String array ");

            Console.WriteLine("\nQuick  sort, random values:");
            DisplayExecutionTime(() => QuickSort(integers, 0, integers.Length - 1), "Int array    ");
            DisplayExecutionTime(() => QuickSort(doubles, 0, doubles.Length - 1), "Double array ");
            DisplayExecutionTime(() => QuickSort(strings, 0, strings.Length - 1), "String array ");

        }

        private static void FillRandomArrayDouble(double[] doubles)
        {
            Random random = new Random();
            for (int i = 0; i < 5000; i++)
            {
                doubles[i] = 5000 - random.NextDouble() * i;
            }
        }

        private static void FillRandomArrayInt(int[] integers)
        {
            Random random = new Random();
            for (int i = 0; i < 5000; i++)
            {
                integers[i] = random.Next(5001);
            }
        }

        private static void FillRandomArrayString(string[] strings)
        {
            Random random = new Random();
            for (int i = 0; i < 5000; i++)
            {
                strings[i] = "word" + random.Next(5001);
            }
        }

        private static void FillArrayDouble(double[] doubles)
        {
            for (int i = 0; i < 5000; i++)
            {
                doubles[i] = 5000 - i * 0.5;
            }
        }

        private static void FillArrayInt(int[] integers)
        {
            for (int i = 0; i < 5000; i++)
            {
                integers[i] = 5000 - i;
            }
        }

        private static void FillArrayString(string[] strings)
        {
            int k = 5000;
            for (int i = 0; i < 5000; i++)
            {
                strings[i] = "word" + k;
                k--;
            }
        }
    }
}
