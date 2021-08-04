using System;

namespace ValidTriangleNumber
{
    /// <summary>
    /// 给定一个包含非负整数的数组，你的任务是统计其中可以组成三角形三条边的三元组个数。
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 2, 2, 3, 4 };

            Console.WriteLine(TriangleNumber(nums));

            Console.WriteLine(TriangleNumber1(nums));
        }

        static int TriangleNumber(int[] nums)
        {
            Array.Sort(nums);
            int n = nums.Length;
            int res = 0;
            for (int i = 0; i < n - 2; i++)
            {
                for (int j = i + 1; j < n - 1; j++)
                {
                    int s = nums[i] + nums[j];
                    int l = j + 1, r = n - 1;
                    while(l < r)
                    {
                        int mid = (l + r + 1) / 2;
                        if (nums[mid] < s)
                            l = mid;
                        else
                            r = mid - 1;
                    }

                    if(nums[r] < s)
                    {
                        res += r - j;
                    }
                }
            }

            return res;
        }

        /// <summary>
        /// 确定一条场边，再使用双指针去寻找满足条件的（两边之和大于第三边）另外两条边
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        static int TriangleNumber1(int[] nums)
        {
            Array.Sort(nums);
            int n = nums.Length;
            int res = 0;
            for(int i = n - 1; i >= 2; i--)
            {
                int l = 0, r = i - 1;

                while(l < r)
                {
                    if(nums[l] + nums[r] <= nums[i])
                    {
                        l++;
                    }
                    else
                    {
                        //l索引之后的其它数据跟r位置的数据组合满足条件
                        res += r - l;
                        r--;
                    }
                }
            }

            return res;
        }
    }
}
