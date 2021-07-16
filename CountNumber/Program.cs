using System;

namespace CountNumber
{
    /// <summary>
    /// 统计一个数字在排序数组中出现的次数
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 5, 7, 7, 8, 8, 10 };
            Console.WriteLine(Search(arr, 8));
        }

        static int Search(int[] nums, int target)
        {
            int leftIndex = BinarySearch(nums, target, true);
            int rightIndex = BinarySearch(nums, target, false) - 1;
            if(leftIndex <= rightIndex && rightIndex < nums.Length && nums[leftIndex] == target && nums[rightIndex] == target)
            {
                return rightIndex - leftIndex + 1;
            }
            return 0;
        }

        /// <summary>
        /// 找第一个target和第一个大于target的下标
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <param name="lower"></param>
        /// <returns></returns>
        static int BinarySearch(int[] nums, int target, bool lower)
        {
            int left = 0, right = nums.Length - 1, ans = nums.Length;
            while(left <= right)
            {
                int mid = (left + right) / 2;
                if(nums[mid] > target || (lower && nums[mid] >= target))
                {
                    right = mid - 1;
                    ans = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return ans;
        }
    }
}
