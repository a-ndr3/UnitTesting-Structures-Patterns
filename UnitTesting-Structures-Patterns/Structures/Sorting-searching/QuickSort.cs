using System;

namespace UnitTesting_Structures_Patterns.Structures.Sorting_searching
{
    /// <summary>
    /// Best,av = nlogn, worst = n^2
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class QuickSort<T> where T : IComparable
    {
        public static void Sort(T[] arr)
        {
            QSort(arr, 0, arr.Length - 1);
        }

        private static void QSort(T[] arr, int low, int high)
        {
            if (low < high)
            {
                int part = Partition(arr, low, high);

                QSort(arr, low, part - 1);
                QSort(arr, part + 1, high);
            }
        }

        private static int Partition(T[] arr, int low, int high)
        {
            var pivot = arr[high];

            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (arr[j].CompareTo(pivot) == -1 || arr[j].CompareTo(pivot) == 0)
                {
                    i++;

                    var temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            var tt = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = tt;

            return (i + 1);

        }
    }
}
