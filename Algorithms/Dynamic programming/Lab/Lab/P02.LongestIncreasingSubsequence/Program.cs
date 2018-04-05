using System;

namespace P02.LongestIncreasingSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] seq = new[] { 3, 14, 5, 12, 15, 7, 8, 9, 11, 10, 1 };

            int[] len = new int[seq.Length];

            for (int index = 0; index < seq.Length; index++)
            {
                len[index] = 1;
                for (int i = 0; i < index - 1; i++)
                {
                    if (seq[i] < seq[index] && len[i] + 1 > len[x]
                    {
                        len[i] = 1 + len[i];
                    }
                }
            }
        }
    }
}
