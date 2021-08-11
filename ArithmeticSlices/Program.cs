using System;

namespace ArithmeticSlices
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
            int n = nums.Length;
            if (n == 1)
                return 0;
            
            int d = nums[0] - nums[1], t = 0;
            int ans = 0;
            for(int i = 2; i< n; i++)
            {
                if(nums[i - 1] - nums[i] == d)
                {
                    ++t;
                }
                else
                {
                    d = nums[i - 1] - nums[i];
                    t = 0;
                }
                ans += t;
            }

            return ans;
        }
    }
}
