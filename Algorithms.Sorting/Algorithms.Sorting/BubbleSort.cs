using Algorithms.Common;
using System;

namespace Algorithms.Sorting
{
    public class BubbleSort<T> : AlgotithmBase<T> where T : IComparable
    {
        private static string algorithmName = "Bubble Sort Algorithm";

        public BubbleSort() : base(algorithmName)
        {
        }

        public override void Sort(T[] array, SortOrder sortOrder)
        {
            Sort(array, Compare(sortOrder));
        }

        public override void Sort(T[] array, Comparison<T> comparison = null)
        {
            if (comparison == null)
                comparison = comparisonDefault;

            for (int j = array.Length - 1; j > 0; j--)
                for (int i = 0; i < j; i++)
                {
                    if (comparison.Invoke(array[i], array[i + 1]) >= 1)
                    {
                        Swop(i + 1, i, array);
                    }
                }
        }


    }

}
