using System;
using System.Linq;
using System.Collections.Generic;

namespace FindMajorityElementLCCI
{
    /// <summary>
    /// 数组中占比超过一半的元素称之为主要元素。给你一个 整数 数组，找出其中的主要元素。若没有，返回 -1 。请设计时间复杂度为 O(N) 、空间复杂度为 O(1) 的解决方案
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 2, 5, 9, 5, 9, 5, 5, 5 };
            Console.WriteLine(MajorityElement(arr));
            Console.WriteLine(MajorityElement_BooyerMoore(arr));
        }

        static int MajorityElement(int[] nums)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            foreach (int i in nums)
            {
                if(dic.ContainsKey(i))
                {
                    dic[i]++;
                }
                else
                {
                    dic.Add(i, 1);
                }
            }

            foreach (var i in dic)
            {
                if(i.Value > nums.Length / 2)
                {
                    return i.Key;
                }
            }

            return -1;
        }

        static int MajorityElement_BooyerMoore(int[] nums)
        {
            int candidate = -1, count = 0;
            foreach (var num in nums)
            {
                if(count == 0)
                {
                    candidate = num;
                }
                if(num == candidate)
                {
                    count++;
                }
                else
                {
                    count--;
                }
            }

            count = 0;
            int length = nums.Length;
            foreach (var num in nums)
            {
                if(num == candidate)
                    count++;
            }

            return count * 2 > length ? candidate : -1;
        }
    }
}
