using System;

namespace UnitTesting_Structures_Patterns.Structures.Sorting_searching
{
    /// <summary>
    /// Best = o(n), worst/av = o(n^2)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class InsertionSort<T> where T : IComparable
    {
        public static void Sort(T[] arr)
        {

            for (int i = 1; i < arr.Length; i++)
            {
                var cur = arr[i];
                var j = i - 1;

                while (j >= 0 && cur.CompareTo(arr[j]) == -1)
                {
                    arr[j + 1] = arr[j];
                    --j;
                }

                arr[j + 1] = cur;
            }
        }
    }
}
