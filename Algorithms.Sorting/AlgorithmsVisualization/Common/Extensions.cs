using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsVisualization.Common
{
    public static class Extensions
    {
        private static int[] algoritmNameValuesSet = (int[])Enum.GetValues(typeof(Algorithm));
        public static Algorithm ConvertToAlgoritmName(this string value)
        {
            Algorithm result;
            return (Enum.TryParse(value, out result) && Array.BinarySearch(algoritmNameValuesSet, (int)result) >= 0)
                ? result
                : Algorithm.Unknown;
        }

        public static TEnum ConvertToEnum<TEnum>(this string value) where TEnum : struct
        {
            return (Enum.TryParse(value, out TEnum result))
                ? result
                : default;
        }
    }
}
