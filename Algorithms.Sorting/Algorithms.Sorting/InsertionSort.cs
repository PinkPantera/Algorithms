using Algorithms.Common;
using System;

namespace Algorithms.Sorting
{
    //public class InsertionSort<T> : AlgotithmBase<T> where T : IComparable
    //{
    //    private static string algorithmName = "Insertion Sort Algorithm";

    //    public InsertionSort() : base(algorithmName)
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

    //        for (int i = 1; i < array.Length; i++)
    //        {
    //            T elementInsert = array[i];
    //            int j = i;
    //            while ((j > 0) && (comparison.Invoke(array[j - 1], elementInsert) >= 1))
    //            {
    //                InsertItem(array[j - 1], j, array);
    //                //array[j] = array[j - 1];
    //                j--;
    //            }

    //            InsertItem(elementInsert, j, array);
    //            //array[j] = elementInsert;
    //        }
    //    }
    //}
}
