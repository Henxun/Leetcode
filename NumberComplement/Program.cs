using System;

namespace NumberComplement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static int FindComplement(int num)
        {
            int highbit = 0;
            for(int i = 1; i <= 30; i++)
            {
                if (num >= (1 << i))
                {
                    highbit = i;
                }
                else
                    break;
            }

            //确保不会溢出
            int mask = highbit == 30 ? 0x7fffffff : (1 << (highbit + 1)) - 1;
            return num ^ mask;
        }
    }
}
