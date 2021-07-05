using System;
using System.Text;

namespace AddBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(AddBinary("11", "1"));
        }

        static string AddBinary(string a, string b)
        {
            int aLen = a.Length, bLen = b.Length, maxLen = Math.Max(aLen, bLen), carry = 0;
            StringBuilder result = new StringBuilder();
            for(int i = 0; i < maxLen; i++)
            {
                carry += i < aLen ? (a[aLen - i - 1] - '0') : 0;
                carry += i < bLen ? (b[bLen - i - 1] - '0') : 0;

                result.Insert(0, carry % 2);
                carry = carry / 2;
            }

            if(carry > 0)
            {
                result.Insert(0, '1');
            }

            return result.ToString();
        }
    }
}
