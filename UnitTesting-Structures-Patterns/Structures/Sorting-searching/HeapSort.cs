using System;

namespace UnitTesting_Structures_Patterns.Structures.Sorting_searching
{
    public static class HeapSort<T> where T : IComparable
    {
        public static void Sort(T[] arr)
        {
            var size = arr.Length;

            for (int i = size / 2 - 1; i >= 0; i--)
            {
                Heapify(arr, size, i);
            }

            for (int i = size - 1; i >= 0; i--)
            {
                var temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;

                Heapify(arr, i, 0);
            }
        }

        private static void Heapify(T[] arr, int n, int larg)
        {
            var largest = larg;
            int l = 2 * larg;
            int r = 2 * larg + 1;

            if (l < n && arr[l].CompareTo(arr[largest]) == 1)
            {
                largest = l;
            }
            if (r < n && arr[r].CompareTo(arr[largest]) == 1)
            {
                largest = r;
            }

            if (largest != larg)
            {
                var temp = arr[larg];
                arr[larg] = arr[largest];
                arr[largest] = temp;
                Heapify(arr, n, largest);
            }

        }

    }
}
