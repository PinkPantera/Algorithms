using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Media;

namespace AlgorithmsVisualization.Common
{
    public class ElementWithColor : INotifyPropertyChanged
    {
        private int element;
        private Brush color;
        private Brush unsorted = new SolidColorBrush(Colors.Gray);
        private bool sorted;

        public ElementWithColor(int element)
        {
            Element = element;
            Color = unsorted;
            Sorted = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public int Element
        {
            get { return element; }
            set
            {
                if (element != value)
                {
                    element = value;
                    OnPropertyChanged();
                }
            }
        }
        public Brush Color
        {
            get { return color; }
            set
            {
                if (color != value)
                {
                    color = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool Sorted
        {
            get { return sorted; }
            private set
            {
                if (sorted != value)
                {
                    sorted = value;
                    OnPropertyChanged();
                }
            }
        }

        public void SelectElementCompare()
        {
            Color = new SolidColorBrush(Colors.Aqua);
        }
        public void SelectElementSwap()
        {
            Color = new SolidColorBrush(Colors.Red);
        }

        public void SelectElementSorted()
        {
            Sorted = true;
            Color = new SolidColorBrush(Colors.GreenYellow);
        }

        public void DeselectElement()
        {
            Color = unsorted;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
