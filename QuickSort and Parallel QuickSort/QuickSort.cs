using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuickSort_and_Parallel_QuickSort
{
    static class QuickSort
    {
        public static void Swap<T>(IList<T> arr, int i, int j)
        {             ///     Zamienia wartości tablicy leżące na indeksach i,j             
            var tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = tmp;
        } 

        public static int Partition<T>(IList<T> arr, int low, int high) where T : IComparable<T>
        {             
        ///Dzieli tablicę na wycinki i porównuje ze sobą wycinki             
        //////Podział wybrany po środku tablicy            
        int pivotPos = (high + low) / 2;
        T pivot = arr[pivotPos];
        /// zamiana dla uproszczenia pętli             
        Swap(arr, low, pivotPos);
        int left = low;
        for (var i = low + 1; i <= high; i++) {
            if (arr[i].CompareTo(pivot) >= 0) continue;
            left++; 
            Swap(arr, i, left);
            }
        Swap(arr, low, left); 
        return left;
        }

        /// Sekwencyjny Quicksort         
        public static void SequentialSort<T>(IList<T> arr, int left, int right) where T : IComparable<T>
        {
            if (right <= left) return; 
            var pivot = Partition(arr, left, right);
            SequentialSort(arr, left, pivot - 1); ///na lewo od podziału             
            SequentialSort(arr, pivot + 1, right); ///na prawdo od podziału         
        } 

        ///Zrównoleglony Quicksort
        public static void ParallelSort<T>(IList<T> arr, int left, int right) where T : IComparable<T>
        {
            if (right <= left) return;
            /// Podział                 
            var pivot = Partition(arr, left, right);
            /// Zrównoleglone sortowanie                 
            System.Threading.Tasks.Parallel.Invoke( 
                () => SequentialSort(arr, left, pivot - 1),
                () => SequentialSort(arr, pivot + 1, right)
            );
        }
        public static void DoublePS<T>(IList<T> arr, int left, int right) where T : IComparable<T>
        {
            if (right <= left) return;
            /// Podział                 
            var pivot = Partition(arr, left, right);
            /// Zrównoleglone sortowanie                 
            System.Threading.Tasks.Parallel.Invoke(
                () => ParallelSort(arr, left, pivot - 1),
                () => ParallelSort(arr, pivot + 1, right)
            );
        }
        public static void FullRecursion<T>(IList<T> arr, int left, int right) where T : IComparable<T>
        {
            if (right <= left) return;
            /// Podział                 
            var pivot = Partition(arr, left, right);
            /// Zrównoleglone sortowanie                 
            System.Threading.Tasks.Parallel.Invoke(
                () => FullRecursion(arr, left, pivot - 1),
                () => FullRecursion(arr, pivot + 1, right)
            );
        }
    }
}
