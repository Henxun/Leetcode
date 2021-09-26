using System;

namespace SumOfTwoIntegers
{
    //给你两个整数 a 和 b ，不使用 运算符 + 和 - ​​​​​​​，计算并返回两整数之和。
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetSum(2, 3));
        }

        static int GetSum(int a, int b)
        {
            while(b != 0)
            {
                int carry = (a & b) << 1;
                a = a ^ b;
                b = carry;
            }
            return a;
        }
    }
}
