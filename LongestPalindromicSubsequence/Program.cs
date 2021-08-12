using System;

namespace LongestPalindromicSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(LongestPalindromeSubseq("bbbab"));
        }

        /// <summary>
        /// dp
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static int LongestPalindromeSubseq(string s)
        {
            int n = s.Length;
            int[,] f = new int[n,n];
            for (int i = n - 1; i >= 0; i--)
            {
                f[i,i] = 1;
                for (int j = i + 1; j < n; j++)
                {
                    if (s[i] == s[j])
                    {
                        f[i,j] = f[i + 1,j - 1] + 2;
                    }
                    else
                    {
                        f[i,j] = Math.Max(f[i + 1,j], f[i,j - 1]);
                    }
                }
            }
            return f[0, n - 1];
        }
    }
}
