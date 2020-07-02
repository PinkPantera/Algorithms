using Algorithms.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Sorting
{
    public abstract class AlgotithmBase<T> where T : IComparable
    {
        protected static Comparison<T> comparisonDefault = (a, b) => a.CompareTo(b);
        protected static Comparison<T> comparisonDecreasing = (a, b) => b.CompareTo(a);

        public AlgotithmBase(string algorithmName)
        {
            AlgorithmName = algorithmName;
        }

        public string AlgorithmName { get; }
        abstract public void Sort(T[] array, SortOrder sortOrder);
        abstract public void Sort(T[] array, Comparison<T> comparison = null);

        protected void Swop(int indexA, int indexB, T[] unSortedArray)
        {
            if (indexA < unSortedArray.Length && indexB < unSortedArray.Length)
            {
                var tmp = unSortedArray[indexA];
                unSortedArray[indexA] = unSortedArray[indexB];
                unSortedArray[indexB] = tmp;
            }
        }

        protected Comparison<T> Compare(SortOrder sortOrder)
        {
            if (sortOrder == SortOrder.Increasing)
                return comparisonDefault;
            return comparisonDecreasing;
        }
    }
}
