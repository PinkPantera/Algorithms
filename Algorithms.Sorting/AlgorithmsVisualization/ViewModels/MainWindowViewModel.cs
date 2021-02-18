using Algorithms.Common;
using Algorithms.Sorting;
using AlgorithmsVisualization.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace AlgorithmsVisualization.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly BubbleSort<int> bubbleSort;
        private int[] arrayInt;
        private string currentElement;
        private Algorithm algorithmName;

        public MainWindowViewModel(Dispatcher dispatcher)
        {
            var observable = Observable.Interval(TimeSpan.FromSeconds(1));

            observable.ObserveOn(SynchronizationContext.Current).Subscribe(num =>
            {
                CurrentElement = $"{arrayInt[0].ToString()} {arrayInt[1].ToString()} {arrayInt[2].ToString()} {arrayInt[3].ToString()}";
            });

            bubbleSort = new BubbleSort<int>();
            arrayInt = new int[5] { 8, 2, 18, 3, 1 };

            CollectionInt = new ObservableCollection<ElementWithColor>();
            for (int i = 0; i < arrayInt.Length; i++)
            {
                CollectionInt.Add(new ElementWithColor(arrayInt[i]));
            }

            RunCommand = new RelayCommand<object>(ExecuteRunCommand);
            MenuCommand = new RelayCommand<object>(ExecuteMenuCommand);
        }

        public Algorithm AlgorithmName
        { 
            get { return algorithmName; } 
            set
            {
                SetProperty(ref algorithmName, value);
            }
        }
        public string CurrentElement
        {
            get { return currentElement; }
            set
            {
                SetProperty(ref currentElement, value);
            }
        }
        public ObservableCollection<ElementWithColor> CollectionInt { get; } = new ObservableCollection<ElementWithColor>();

        public ICommand RunCommand { get; }
        public ICommand MenuCommand { get; }

        #region Commands
        private async void ExecuteRunCommand(object obj)
        {
            var progres = new Progress<(OperationAlgorithm operation, int indA, int indB)>();
            progres.ProgressChanged += Progres_ProgressChanged;

            await bubbleSort.Sort(arrayInt, progres);

        }
        private void ExecuteMenuCommand(object obj)
        {
            if (obj == null)
                return;
            Algorithm alg = obj.ToString().ConvertToEnum<Algorithm>();

            AlgorithmName = alg;
        }
        #endregion Commands

        private void Progres_ProgressChanged(object sender, (OperationAlgorithm operation, int indA, int indB) e)
        {
            foreach (var item in CollectionInt.Where(item => !item.Sorted))
            {
                item.DeselectElement();
            }

            if (e.operation == OperationAlgorithm.Comparison)
            {
                CollectionInt[e.indA].SelectElementCompare();
                CollectionInt[e.indB].SelectElementCompare();
            }
            else if (e.operation == OperationAlgorithm.Swap)
            {
                CollectionInt[e.indA].SelectElementSwap();
                CollectionInt[e.indB].SelectElementSwap();
                var tmp = CollectionInt[e.indA];
                CollectionInt.Move(e.indA, e.indB);
                CollectionInt[e.indB] = tmp;
            }
            else if (e.operation == OperationAlgorithm.Sorted)
            {
                //for (int i = e.indA; i < e.indB; i++)
                //{
                CollectionInt[e.indA].SelectElementSorted();
                // }
            }
        }

    }
}
