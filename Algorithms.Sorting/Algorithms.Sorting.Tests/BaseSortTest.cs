using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Sorting.Tests
{
    public abstract class BaseSortTest
    {
        #region Helpers methods

        protected bool ArraysAreEqual<T>(T[] array1, T[] array2)
        {
            if (array1 == null || array2 == null)
                return false;

            if (array1.Length != array2.Length)
                return false;

            for (int i = 0; i < array1.Length; i++)
                if (!array1[i].Equals(array2[i]))
                    return false;

            return true;
        }

        protected static int[] GenerateArrayInt(int count)
        {
            var arr = new int[count];
            var rnd = new Random();
            for (int i = 0; i < count; i++)
            {
                arr[i] = rnd.Next(0, 100);
            }
            return arr;
        }

        protected static string[] GenerateArrayString()
        {
            return new string[] { "f", "mars", "is", "w", "n", "a", "ia", "juin", "is", "w", "juillet", "a", "mai" };
        }

        #endregion Helpers methods
    }
}
