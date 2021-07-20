using System;

namespace MinimizeMaximumPairSumInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 3, 5, 2, 3 };            
            Console.WriteLine(MinPairSum(arr));
        }

        static int MinPairSum(int[] nums)
        {
            int res = 0, len = nums.Length;
            for (int i = 0; i < len / 2; i++)
            {
                res = Math.Max(res, nums[i] + nums[len - i - 1]);
            }
            return res;
        }
    }
}
