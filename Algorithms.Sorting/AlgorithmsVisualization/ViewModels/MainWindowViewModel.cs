using Algorithms.Common;
using Algorithms.Sorting;
using AlgorithmsVisualization.Common;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
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
        private int arraySize;
        private bool runEnabled;
        private CancellationTokenSource cancellationToken;

        public MainWindowViewModel()
        {
            Reset();

            AlgorithmName = Algorithm.BubbleSort;
            bubbleSort = new BubbleSort<int>();

            CollectionInt = new ObservableCollection<ElementWithColor>();
          
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
        public bool RunEnabled
        {
            get { return runEnabled; }
            set 
            {
                SetProperty(ref runEnabled, value);
            }
        }
        public int ArraySize
        {
            get { return arraySize; }
            set
            {
                SetProperty(ref arraySize, value);
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
            InitArrayForSort();
            cancellationToken = new CancellationTokenSource();
            if (AlgorithmName == Algorithm.BubbleSort)
            {
                RunEnabled = false;
                await bubbleSort.Sort(arrayInt, progres, cancellationToken.Token).ContinueWith((_)=>
                {
                     RunEnabled = true;
                });
            }
        }

        private void ExecuteMenuCommand(object obj)
        {
            if (obj == null)
                return;
            Algorithm alg = obj.ToString().ConvertToEnum<Algorithm>();

            AlgorithmName = alg;
            Reset();
        }
        #endregion Commands
        private void Reset()
        {
            cancellationToken?.Cancel();
            RunEnabled = true;
            ArraySize = 10;
        }

        private void InitArrayForSort()
        {
            var rng = new Random();

            arrayInt = new int[ArraySize];

            for (int i = 0; i < ArraySize; i++)
            {
                arrayInt[i] = rng.Next(0, 100);
            }

            CollectionInt.Clear();
            for (int i = 0; i < arrayInt.Length; i++)
            {
                CollectionInt.Add(new ElementWithColor(arrayInt[i]));
            }
        }

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
                CollectionInt[e.indA].SelectElementSorted();
            }
        }

    }
}
