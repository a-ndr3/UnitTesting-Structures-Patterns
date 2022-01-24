using System;

namespace UnitTesting_Structures_Patterns.Structures.Sorting_searching
{
    public static class BinarySearch<T> where T : IComparable
    {
        /// <summary>
        /// Returns [default] if no element found
        /// </summary>
        /// <param name="element">value to be searched</param>
        /// <param name="arr"></param>
        /// <param name="sorted">true - needs to be sorted / false - is already sorted</param>
        /// <returns></returns>
        public static T Search(T element, T[] arr, bool sorted = true)
        {
            if (!sorted) QuickSort<T>.Sort(arr);
            return dSearch(element, arr, 0, arr.Length - 1);
        }

        private static T dSearch(T element, T[] arr, int l, int h)
        {
            if (l > h)
            {
                return default;
            }

            var m = (l + h) / 2;

            if (element.CompareTo(arr[m]) == 0)
            {
                return arr[m];
            }
            else if (element.CompareTo(arr[m]) == 1)
            {
                return dSearch(element, arr, m + 1, h);
            }
            else
            {
                return dSearch(element, arr, l, m - 1);
            }
        }
    }
}
