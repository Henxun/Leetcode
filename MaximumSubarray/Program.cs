using System;

namespace MaximumSubarray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MaxSubArray(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }));
        }
        static int MaxSubArray(int[] nums)
        {
            int pre = 0, maxAns = nums[0];

            foreach (var num in nums)
            {
                pre = Math.Max(pre + num, num);
                maxAns = Math.Max(maxAns, pre); 
            }
            return maxAns;
        }
    }
}
