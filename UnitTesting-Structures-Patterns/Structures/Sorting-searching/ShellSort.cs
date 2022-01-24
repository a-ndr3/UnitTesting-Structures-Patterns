using System;

namespace UnitTesting_Structures_Patterns.Structures.Sorting_searching
{
    /// <summary>
    /// Best,av = nlogn,worst = n^2
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class ShellSort<T> where T : IComparable
    {
        public static void Sort(T[] arr)
        {
            for (int i = arr.Length / 2; i > 0; i /= 2)
            {
                for (int j = i; j < arr.Length; j++)
                {
                    var temp = arr[j];
                    int x = 0;
                    for (x = j; x >= i && arr[x - i].CompareTo(temp) == 1; x -= i)
                    {
                        arr[x] = arr[x - i];
                    }

                    arr[x] = temp;
                }
            }
        }
    }
}
