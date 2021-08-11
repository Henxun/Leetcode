﻿using System;
using System.Collections.Generic;

namespace ArithmeticSlicesIISubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 2, 4, 6, 8, 10 };
            Console.WriteLine(NumberOfArithmeticSlices(nums));
        }

        static int NumberOfArithmeticSlices(int[] nums)
        {
            int ans = 0;
            int n = nums.Length;
            Dictionary<long, int>[] f = new Dictionary<long, int>[n];
            for (int i = 0; i < n; ++i)
            {
                f[i] = new Dictionary<long, int>();
            }
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < i; ++j)
                {
                    long d = 1L * nums[i] - nums[j];
                    int cnt = f[j].ContainsKey(d) ? f[j][d] : 0;
                    ans += cnt;
                    if (f[i].ContainsKey(d))
                    {
                        f[i][d] += cnt + 1;
                    }
                    else
                    {
                        f[i].Add(d, cnt + 1);
                    }
                }
            }
            return ans;
        }
    }
}
