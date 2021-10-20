using System;
using System.Linq;

namespace MinimumMovesToEqualArrayElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static int MinMoves(int[] nums)
        {
            int min = nums.Min();
            int res = 0;

            foreach (int i in nums)
            {
                res += i - min;
            }

            return res;
        }
    }
}
