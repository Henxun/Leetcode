using System;

namespace RangeCovered
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static bool IsCovered(int[][] ranges, int left, int right)
        {
            bool[] flags = new bool[51];

            foreach (var i in ranges)
            {
                for(int j = i[0]; j <= i[1]; j++)
                {
                    flags[j] = true;
                }
            }

            for(int i = left; i <= right; i++)
            {
                if (!flags[i])
                    return false;
            }
            return true;
        }
    }
}
