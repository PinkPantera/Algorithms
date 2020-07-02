using Algorithms.Common;
using System;

namespace Algorithms.Sorting
{
    public class BubbleSort<T> : AlgotithmBase<T> where T : IComparable
    {
        private static string algorithmName = "Bubble Sort Algorith";
        public BubbleSort(): base (algorithmName)
        {
        }

        public override void Sort(T[] array, SortOrder sortOrder)
        {
            for (int j = array.Length - 1; j > 0; j--)
                for (int i = 0; i < j; i++)
                {
                    var tmp = Compare(array[i], array[i + 1], sortOrder);
                    if (tmp >= 1)
                    {
                        Swop(i + 1, i, array);
                    }
                }
        }

    }

}
