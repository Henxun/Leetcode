using System;

namespace ContainerWithMostWater
{
    /// <summary>
    /// 给你 n 个非负整数 a1，a2，...，an，每个数代表坐标中的一个点 (i, ai) 。在坐标内画 n 条垂直线，垂直线 i 的两个端点分别为 (i, ai) 和 (i, 0) 。找出其中的两条线，使得它们与 x 轴共同构成的容器可以容纳最多的水
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[] height = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
            Console.WriteLine(MaxArea(height));
        }

        static int MaxArea(int[] height)
        {
            int l = 0, r = height.Length - 1;
            int ans = 0;

            while(l < r)
            {
                int area = (r - l) * Math.Min(height[l], height[r]);
                ans = Math.Max(ans, area);
                if(height[l] < height[r])
                {
                    l++;
                }
                else
                {
                    r--;
                }
            }
            return ans;
        }
    }
}
