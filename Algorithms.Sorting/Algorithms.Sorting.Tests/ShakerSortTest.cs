using Algorithms.Common;
using NUnit.Framework;
using System;

namespace Algorithms.Sorting.Tests
{
    public class ShakerSortTest : BaseSortTest
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
            //var arrayInt = new int[10] {5,2,1,3,9,0,4,6,8,7 };
            var arrayIntExpected = (int[])arrayInt.Clone();
            Array.Sort<int>(arrayIntExpected, (a, b) => a.CompareTo(b));

            var shakerSort = new ShakerSort<int>();

            //act
            shakerSort.Sort(arrayInt);

            //assert
            var result = ArraysAreEqual<int>(arrayInt, arrayIntExpected);
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

            var shakerSort = new ShakerSort<int>();

            //act
            shakerSort.Sort(arrayInt, SortOrder.Increasing);

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

            var shakerSort = new ShakerSort<int>();

            //act
            shakerSort.Sort(arrayInt, SortOrder.Decreasing);

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

            var shakerSort = new ShakerSort<string>();

            //act
            shakerSort.Sort(arrayString);

            //assert
            var result = ArraysAreEqual<string>(arrayString, arrayStringExpected);
            Assert.IsTrue(result);
        }

        [Test]
        public void SortStringIncreasing()
        {
            //arrange
            var arrayString = GenerateArrayString();

            var arrayStringExpected = (string[])arrayString.Clone();
            Array.Sort<string>(arrayStringExpected, (a, b) => a.CompareTo(b));

            var shakerSort = new ShakerSort<string>();

            //act
            shakerSort.Sort(arrayString, SortOrder.Increasing);

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

            var shakerSort = new ShakerSort<string>();

            //act
            shakerSort.Sort(arrayString, SortOrder.Decreasing);

            //assert
            var result = ArraysAreEqual<string>(arrayString, arrayStringExpected);
            Assert.IsTrue(result);
        }

    }
}
