using System;

namespace UnitTesting_Structures_Patterns.Structures.Sorting_searching
{
    /// <summary>
    /// Best,worst,av = o(nlogn)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class MergeSort<T> where T : IComparable<T>
    {
        public static void Sort(T[] arr)
        {
            HiddenSort(arr, 0, arr.Length - 1);
        }

        private static void HiddenSort(T[] arr, int l = 0, int r = 0)
        {
            if (l < r)
            {
                int m = (l + r) / 2;
                HiddenSort(arr, l, m);
                HiddenSort(arr, m + 1, r);

                Merge(arr, l, m, r);
            }
        }

        private static void Merge(T[] arr, int left, int middle, int right)
        {
            var pos1 = middle - left + 1;
            var pos2 = right - middle;

            var L = new T[pos1];
            var M = new T[pos2];

            for (int i = 0; i < pos1; i++)
            {
                L[i] = arr[left + i];
            }
            for (int j = 0; j < pos2; j++)
            {
                M[j] = arr[middle + 1 + j];
            }

            int n = 0; int m = 0;
            int l = left;

            while (n < pos1 && m < pos2)
            {
                var comp = L[n].CompareTo(M[m]);
                if (comp == -1 || comp == 0)
                {
                    arr[l] = L[n]; n++;
                }
                else
                {
                    arr[l] = M[m];
                    m++;
                }
                l++;
            }

            while (n.CompareTo(pos1) == -1)
            {
                arr[l] = L[n];
                n++;
                l++;
            }

            while (m.CompareTo(pos2) == -1)
            {
                arr[l] = M[m];
                m++;
                l++;
            }

        }
    }
}
