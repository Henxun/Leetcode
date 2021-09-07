using System;

namespace SplitAStringInBalancedStrings
{
    //在一个 平衡字符串 中，'L' 和 'R' 字符的数量是相同的。
    //给你一个平衡字符串 s，请你将它分割成尽可能多的平衡字符串。
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(BalancedStringSplit("RLRRLLRLRL"));
        }

        static int BalancedStringSplit(string s)
        {
            int ans = 0, d = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if(s[i] == 'L')
                {
                    d++;
                }
                else
                {
                    d--;
                }
                if(d == 0)
                {
                    ans++;
                }
            }
            return ans;
        }
    }
}
