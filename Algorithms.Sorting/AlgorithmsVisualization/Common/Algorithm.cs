using AlgorithmsVisualization.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AlgorithmsVisualization.Common
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum Algorithm
    {
        Unknown = 0,
        [LocalizedDescription(nameof(Resource.BubbleSortTxt), typeof(Resource))]
        BubbleSort,
        [LocalizedDescription(nameof(Resource.InsertionSortTxt), typeof(Resource))]
        InsertionSort,
        [LocalizedDescription(nameof(Resource.ShakerSortTxt), typeof(Resource))]
        ShakerSort,
    }
}
