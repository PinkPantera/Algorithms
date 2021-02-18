using Algorithms.Common;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    public class BubbleSort<T> : AlgotithmBase<T> where T : IComparable
    {
        private static string algorithmName = "Bubble Sort Algorithm";

        public BubbleSort() : base(algorithmName)
        {
        }

        public override Task Sort(T[] array, SortOrder sortOrder, IProgress<(OperationAlgorithm operation, int indA, int indB)> progress)
        {
            return Sort(array, progress, Compare(sortOrder));
        }

        public override Task Sort(T[] array, IProgress<(OperationAlgorithm operation, int indA, int indB)> progress, Comparison<T> comparison = null)
        {
            var tcs = new TaskCompletionSource<bool>();

            Task.Run(() =>
           {
               try
               {
                   if (comparison == null)
                       comparison = comparisonDefault;

                   for (int j = array.Length - 1; j > 0; j--)
                   {
                       for (int i = 0; i < j; i++)
                       {
                           if (progress != null)
                           {
                               progress.Report((OperationAlgorithm.Comparison, i, i + 1));
                               Thread.Sleep(2000);
                           }

                           if (comparison.Invoke(array[i], array[i + 1]) >= 1)
                           {
                               Swop(i + 1, i, array, progress);
                           }
                       }

                       if (progress != null)
                       {
                           progress.Report((OperationAlgorithm.Sorted, j, array.Length));
                           Thread.Sleep(1000);
                       }
                   }

                   if (progress != null)
                   {
                       progress.Report((OperationAlgorithm.Sorted, 0, array.Length));
                   }

                   tcs.SetResult(true);
               }
               catch (Exception ex)
               {
                   tcs.SetException(ex);

               }

           });

            return tcs.Task;
        }
    }

}
