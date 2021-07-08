using System;
using System.Collections.Generic;

namespace BinarySubarraysWithSum
{
    /// <summary>
    /// 给你一个二元数组 nums ，和一个整数 goal ，请你统计并返回有多少个和为 goal 的 非空 子数组。
    /// 子数组 是数组的一段连续部分。
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 1, 0, 1, 0, 1 };
            Console.WriteLine(NumSubarraysWithSum(arr, 2));
        }

        static int NumSubarraysWithSum(int[] nums, int goal)
        {
            int sum = 0, ans = 0;
            Dictionary<int, int> dic = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if(dic.ContainsKey(sum))
                {
                    dic[sum]++;
                }
                else
                {
                    dic.Add(sum, 1);
                }

                sum += num;
                dic.TryGetValue(sum - goal, out int val);
                ans += val;
            }
            return ans;
        }
    }
}
