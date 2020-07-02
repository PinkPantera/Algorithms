using Algorithms.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Algorithms.Sorting.Tests
{
    public class BubbleSortTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SortIntComparisonDefault()
        {
            //arrange
            var countElements = 100;
            var arrayInt = GenerateArrayInt(countElements);
            var arrayIntExpected = (int[])arrayInt.Clone();
            Array.Sort<int>(arrayIntExpected, (a, b) => a.CompareTo(b));

            var bubleSort = new BubbleSort<int>();

            //act
            bubleSort.Sort(arrayInt);

            //assert
            var result = ArraysAreEqual<int>(arrayInt, arrayIntExpected);
            Assert.IsTrue(result);
        }

        [Test]
        public void SortStringComparisonDefault()
        {
            //arrange
            var arrayString = GenerateArrayString();

            var arrayStringExpected = (string[])arrayString.Clone();
            Array.Sort<string>(arrayStringExpected, (a, b) => a.CompareTo(b));

            var countElements = arrayString.Length;

            var bubleSort = new BubbleSort<string>();

            //act
            bubleSort.Sort(arrayString);

            //assert
            var result = ArraysAreEqual<string>(arrayString, arrayStringExpected);
            Assert.IsTrue(result);
        }

        [Test]
        public void SortIntIncreasing()
        {
            //arrange
            var countElements = 100;
            var arrayInt = GenerateArrayInt(countElements);
            var arrayIntExpected = (int[])arrayInt.Clone();
            Array.Sort<int>(arrayIntExpected, (a, b) => a.CompareTo(b));

            var bubleSort = new BubbleSort<int>();

            //act
            bubleSort.Sort(arrayInt, SortOrder.Increasing);

            //assert
            var result = ArraysAreEqual<int>(arrayInt, arrayIntExpected);
            Assert.IsTrue(result);
        }

        [Test]
        public void SortIntDecreasing()
        {
            //arrange
            var countElements = 100;
            var arrayInt = GenerateArrayInt(countElements);
            var arrayIntExpected = (int[])arrayInt.Clone();
            Array.Sort<int>(arrayIntExpected, (a, b) => b.CompareTo(a));

            var bubleSort = new BubbleSort<int>();

            //act
            bubleSort.Sort(arrayInt, SortOrder.Decreasing);

            //assert
            var result = ArraysAreEqual<int>(arrayInt, arrayIntExpected);
            Assert.IsTrue(result);
        }

        [Test]
        public void SortStringIncreasing()
        {
            //arrange
            var arrayString = GenerateArrayString();

            var arrayStringExpected = (string[])arrayString.Clone();
            Array.Sort<string>(arrayStringExpected, (a, b) => a.CompareTo(b));

            var countElements = arrayString.Length;

            var bubleSort = new BubbleSort<string>();

            //act
            bubleSort.Sort(arrayString, SortOrder.Increasing);

            //assert
            var result = ArraysAreEqual<string>(arrayString, arrayStringExpected);
            Assert.IsTrue(result);
        }

        [Test]
        public void SortStringDecreasing()
        {
            //arrange
            var arrayString = GenerateArrayString();

            var arrayStringExpected = (string[])arrayString.Clone();
            Array.Sort<string>(arrayStringExpected, (a, b) => b.CompareTo(a));

            var countElements = arrayString.Length;

            var bubleSort = new BubbleSort<string>();

            //act
            bubleSort.Sort(arrayString, SortOrder.Decreasing);

            //assert
            var result = ArraysAreEqual<string>(arrayString, arrayStringExpected);
            Assert.IsTrue(result);
        }

        #region Helpers methods

        private bool ArraysAreEqual<T>(T[] array1, T[] array2)
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

        private static string[] GenerateArrayString()
        {
            return new string[] { "f", "mars", "is", "w", "n", "a", "ia", "juin", "is", "w", "juillet", "a", "mai" };
        }

        #endregion Helpers methods
    }
}