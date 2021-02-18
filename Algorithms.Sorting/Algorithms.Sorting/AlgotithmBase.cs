using Algorithms.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Common;
using System.Threading;

namespace Algorithms.Sorting
{
    public abstract class AlgotithmBase<T> where T : IComparable
    {
        protected static Comparison<T> comparisonDefault = (a, b) => a.CompareTo(b);
        protected static Comparison<T> comparisonDecreasing = (a, b) => b.CompareTo(a);
        protected Action<int, int> change;

        public AlgotithmBase(string algorithmName)
        {
            AlgorithmName = algorithmName;
        }

        public string AlgorithmName { get; }
        abstract public Task Sort(T[] array, SortOrder sortOrder, IProgress<(OperationAlgorithm operation, int indA, int indB)> progress);
        abstract public Task Sort(T[] array, IProgress<(OperationAlgorithm operation, int indA, int indB)> progress, Comparison<T> comparison = null);

        protected void Swop(int indexA, int indexB, T[] array, IProgress<(OperationAlgorithm operation, int indA, int  indB)> progress)
        {
            if (indexA < array.Length && indexB < array.Length)
            {
                var tmp = array[indexA];
                array[indexA] = array[indexB];
                array[indexB] = tmp;

                if (progress != null)
                {
                    progress.Report((OperationAlgorithm.Swap, indexA, indexB));
                    Thread.Sleep(1000);
                }
            }
        }

        protected void InsertItem(T item, int index, T[] array)
        {
            array[index] = item;
        }

        protected Comparison<T> Compare(SortOrder sortOrder)
        {
            if (sortOrder == SortOrder.Increasing)
                return comparisonDefault;
            return comparisonDecreasing;
        }
    }
}
