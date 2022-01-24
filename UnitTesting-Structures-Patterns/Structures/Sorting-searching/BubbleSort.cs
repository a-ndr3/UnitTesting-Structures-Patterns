using System;

namespace UnitTesting_Structures_Patterns.Structures.Sorting_searching
{
    /// <summary>
    /// Best = o(n), worst/average = o(n^2)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class BubbleSort<T> where T : IComparable
    {
        public static void Sort(T[] data)
        {
            for (int i = 0; i < data.Length - 1; i++)
            {
                bool wasSwap = false;

                for (int j = 0; j < data.Length - i - 1; j++)
                {
                    if (data[j].CompareTo(data[j + 1]) == 1)
                    {
                        var temp = data[j];
                        data[j] = data[j + 1];
                        data[j + 1] = temp;

                        wasSwap = true;
                    }
                }

                if (!wasSwap)
                    break;
            }
        }
    }
}
