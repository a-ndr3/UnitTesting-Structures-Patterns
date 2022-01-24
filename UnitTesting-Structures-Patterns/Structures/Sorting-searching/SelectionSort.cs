using System;

namespace UnitTesting_Structures_Patterns.Structures.Sorting_searching
{
    /// <summary>
    /// Best,worst,av = o(n^2)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class SelectionSort<T> where T : IComparable
    {
        public static void Sort(T[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int min = i;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j].CompareTo(arr[min]) == -1)
                    {
                        min = j;
                    }
                }
                var temp = arr[i];
                arr[i] = arr[min];
                arr[min] = temp;
            }
        }
    }
}
