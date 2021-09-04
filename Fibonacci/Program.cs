using System;

namespace Fibonacci
{
    //写一个函数，输入 n ，求斐波那契（Fibonacci）数列的第 n 项（即 F(N)）。斐波那契数列的定义如下：
    //F(0) = 0,   F(1) = 1
    //F(N) = F(N - 1) + F(N - 2), 其中 N > 1.
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Fib(44));
        }

        static int Fib(int n)
        {
            const int MOD = 1000000007;
            if (n < 2)
                return n;

            int p = 0, q = 0, r = 1;

            for(int i = 2; i < n; i++)
            {
                p = q;
                q = r;
                r = (p + q) % MOD;
            }

            return r;
        }
    }
}
