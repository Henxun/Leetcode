using System;
using System.Collections.Generic;

namespace NumberOfBoomerangs
{
    /// <summary>
    /// 给定平面上 n 对 互不相同 的点 points ，其中 points[i] = [xi, yi] 。回旋镖 是由点 (i, j, k) 表示的元组 ，其中 i 和 j 之间的距离和 i 和 k 之间的距离相等（需要考虑元组的顺序）。返回平面上所有回旋镖的数量。
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static int NumberOfBoomerangs(int[][] points)
        {
            if(points.Length <= 2)
            {
                return 0;
            }

            int ans = 0;
            foreach(int[] point in points)
            {
                Dictionary<int, int> cnt = new Dictionary<int, int>();
                foreach(int[] q in points)
                {
                    int dis = (point[0] - q[0]) * (point[0] - q[0]) + (point[1] - q[1]) * (point[1] - q[1]);
                    if(cnt.ContainsKey(dis))
                    {
                        cnt[dis]++;
                    }else
                    {
                        cnt.Add(dis, 1);
                    }
                }

                foreach (var item in cnt)
                {
                    int m = item.Value;
                    ans += m * (m - 1);
                }
            }

            return ans;
        }
    }
}
