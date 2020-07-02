using Algorithms.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Sorting
{
    public abstract class AlgotithmBase<T> where T : IComparable
    {
        public AlgotithmBase(string algorithmName)
        {
            AlgorithmName = algorithmName;
        }

        public string AlgorithmName { get; }
        abstract public void Sort(T[] array, SortOrder sortOrder);

        protected void Swop(int indexA, int indexB, T[] unSortedArray)
        {
            if (indexA < unSortedArray.Length && indexB < unSortedArray.Length)
            {
                var tmp = unSortedArray[indexA];
                unSortedArray[indexA] = unSortedArray[indexB];
                unSortedArray[indexB] = tmp;
            }
        }

        protected int Compare(T elementA, T elementB, SortOrder sortOrder)
        {
            if (sortOrder == SortOrder.Increasin)
                return elementA.CompareTo(elementB);
            return elementB.CompareTo(elementA);
        }
    }
}
