﻿using System;

namespace PeakIndexInAMountainArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static int PeakIndexInMountainArray(int[] arr)
        {
            int n = arr.Length;
            int left = 1, right = n - 2, ans = 0;
            while(left <= right)
            {
                int mid = (left + right) / 2;
                if(arr[mid] > arr[mid + 1])
                {
                    ans = mid;
                    right = mid - 1;
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
