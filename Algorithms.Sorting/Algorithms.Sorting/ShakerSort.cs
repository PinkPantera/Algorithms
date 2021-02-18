using Algorithms.Common;
using System;

namespace Algorithms.Sorting
{
    //public class ShakerSort<T> : AlgotithmBase<T> where T : IComparable
    //{
    //    private static string algorithmName = "Shaker Sort Algorithm";

    //    public ShakerSort() : base(algorithmName)
    //    {
    //    }

    //    public override void Sort(T[] array, SortOrder sortOrder)
    //    {
    //        Sort(array, Compare(sortOrder));
    //    }

    //    public override void Sort(T[] array, Comparison<T> comparison = null)
    //    {
    //        if (comparison == null)
    //            comparison = comparisonDefault;

    //        int firstIndex = 0;
    //        int lastIndex = array.Length - 1;

    //        while (firstIndex < lastIndex)
    //        {
    //            for (int i = firstIndex; i < lastIndex; i++)
    //            {
    //                if (comparison.Invoke(array[i], array[i + 1]) >= 1)
    //                {
    //                    Swop(i + 1, i, array);
    //                }
    //            }

    //            for (int j = lastIndex - 1; j > firstIndex; j--)
    //            {
    //                if (comparison.Invoke(array[j - 1], array[j]) >= 1)
    //                {
    //                    Swop(j - 1, j, array);
    //                }
    //            }

    //            firstIndex++;
    //            lastIndex--;
    //        }
    //    }
    //}
}
