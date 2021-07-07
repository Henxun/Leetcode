using System;
using System.Collections.Generic;
using System.Linq;

namespace CountGoodMeals
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 1, 3, 5, 7, 9 };

            Console.WriteLine(CountPairs(arr));
        }

        static int CountPairs(int[] deliciousness)
        {
            int ans = 0, maxVal = 0;

            foreach (var num in deliciousness)
            {
                maxVal = Math.Max(maxVal, num);
            }

            int maxSum = 2 * maxVal;
            Dictionary<int, int> dic = new Dictionary<int, int>();

            for (int i = 0; i < deliciousness.Length; i++)
            {
                int val = deliciousness[i];
                //sum每次乘以2，这里是遍历小于数组最大和的2的幂次数，如1，2，4，8...
                for (int sum = 1; sum <= maxSum; sum <<= 1)
                {
                    int count;
                    dic.TryGetValue(sum - val, out count);
                    ans = (ans + count) % 1000000007;
                }
                if(dic.ContainsKey(val))
                {
                    dic[val]++;
                }
                else
                {
                    dic.Add(val, 1);
                }
            }
            return ans;
        }
    }
}
