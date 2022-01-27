using System;

namespace UnitTesting_Structures_Patterns.Structures.Dynamic_other
{
    /// <summary>
    /// CHECK IF CORRECT
    /// </summary>
    public static class LongestCommonSubsequence
    {
        public static char[] GetCommonSequence(string s1, string s2)
        {
            int size1 = s1.Length;
            int size2 = s2.Length;

            var table = new int[size1 + 1, size2 + 1];

            for (int i = 0; i <= size1; i++)
            {
                for (int j = 0; j <= size2; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        table[i, j] = 0;
                    }
                    else if (s1[i - 1] == s2[j - 1])
                    {
                        table[i, j] = table[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        table[i, j] = Math.Max(table[i - 1, j], table[i, j - 1]);
                    }
                }
            }

            var ind = table[size1, size2];

            char[] lcs = new char[ind + 1];
            lcs[ind] = '\0';

            while (size1 > 0 && size2 > 0)
            {
                if (s1[size1 - 1] == s2[size2 - 1])
                {
                    lcs[ind - 1] = s1[size1 - 1];


                    size1--;
                    size2--;
                    ind--;

                }

                else if (table[size1 - 1, size2] > table[size1, size2 - 1])
                {
                    size1--;
                }
                else
                {
                    size2--;
                }
            }
            return lcs;
        }
    }
}
