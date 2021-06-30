using System;

namespace LengthofLastWord
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(LengthOfLastWord("Hello"));
        }

        static int LengthOfLastWord(string s)
        {
            int length = s.Length, count = 0;
            bool flag = false;
            for (int i = length - 1; i >= 0; i--)
            {
                if(s[i] != ' ')
                {
                    flag = true;
                    count++;
                }
                else
                {
                    if (flag) return count;
                }
            }
            return count;
        }
    }
}
