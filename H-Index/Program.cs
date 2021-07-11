using System;

namespace H_Index
{
    /// <summary>
    /// 给定一位研究者论文被引用次数的数组（被引用次数是非负整数）。编写一个方法，计算出研究者的 h 指数。
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 3, 0, 6, 1, 5 };
            Console.WriteLine(HIndex(arr));
        }

        static int HIndex(int[] citations)
        {
            Array.Sort(citations);

            int h = 0, i = citations.Length - 1;

            while(i >= 0 && citations[i] > h)
            {
                h++;
                i--;
            }
            return h;
        }
    }
}
