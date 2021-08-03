using System;

namespace ShortestUnsortedContinuousSubarray
{
    /// <summary>
    /// 给你一个整数数组 nums ，你需要找出一个 连续子数组 ，如果对这个子数组进行升序排序，那么整个数组都会变为升序排序。
    /// 请你找出符合题意的 最短 子数组，并输出它的长度。
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new int[] { 2, 6, 4, 8, 10, 9, 15 };
            Console.WriteLine(FindUnsortedSubarray(nums));
            Console.WriteLine(FindUnsortedSubarray1(nums));
        }

        /// <summary>
        /// 根据排序数组找出原数组中最先出现错序和最后出现错序的索引
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        static int FindUnsortedSubarray(int[] nums)
        {
            if (IsSorted(nums))
                return 0;

            int[] sortNums = new int[nums.Length];
            Array.Copy(nums, 0, sortNums, 0, nums.Length);
            Array.Sort(sortNums);
            int left = 0;
            while (nums[left] == sortNums[left])
                left++;

            int right = nums.Length - 1;
            while (nums[right] == sortNums[right])
                right--;

            return right - left + 1;
        }

        static bool IsSorted(int[] nums)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] > nums[i + 1])
                    return false;
            }
            return true;
        }

        static int FindUnsortedSubarray1(int[] nums)
        {
            int n = nums.Length;
            int maxValue = int.MinValue, right = -1;
            int minValue = int.MaxValue, left = -1;

            for (int i = 0; i < n; i++)
            {
                if(maxValue > nums[i])
                {
                    right = i;
                }
                else
                {
                    maxValue = nums[i];
                }

                if(minValue < nums[n - i - 1])
                {
                    left = n - i - 1;
                }
                else
                {
                    minValue = nums[n - i - 1];
                }
            }

            return right == -1 ? 0 : right - left + 1;
        }
    }
}
