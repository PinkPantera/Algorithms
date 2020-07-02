using Algorithms.Common;
using Algorithms.Sorting;
using System;

namespace Algorithms.Start
{
    class Program
    {
        static void Main(string[] args)
        {
            BubbleSortInt();
            Console.WriteLine();

            BubbleSortSring();
            Console.ReadLine();
        }

        private static int[] GenerateArrayInt(int count)
        {
            var arr = new int[count];
            var rnd = new Random();
            for (int i = 0; i < count; i++)
            {
                arr[i] = rnd.Next(0, 100);
            }
            return arr;
        }

        private static void BubbleSortInt()
        {
            var bubbleSortInt = new BubbleSort<int>();
            Console.WriteLine(bubbleSortInt.AlgorithmName);

            foreach (SortOrder sortOrder in Enum.GetValues(typeof(SortOrder)))
            {
                var array = GenerateArrayInt(10);
                Console.WriteLine(sortOrder.ToString());

                bubbleSortInt.Sort(array, sortOrder);

                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write($"{array[i]}, ");
                }
                Console.WriteLine();
            }
        }

        private static void BubbleSortSring()
        {
            var bubbleSortSring = new BubbleSort<string>();
            Console.WriteLine(bubbleSortSring.AlgorithmName);

            foreach (SortOrder sortOrder in Enum.GetValues(typeof(SortOrder)))
            {
                var arrayString = new string[] { "f", "is", "w", "n", "a", "ia" };
                Console.WriteLine(sortOrder.ToString());

                bubbleSortSring.Sort(arrayString, sortOrder);

                for (int i = 0; i < arrayString.Length; i++)
                {
                    Console.Write($"{arrayString[i]}, ");
                }
                Console.WriteLine();
            }
        }
    }
}
