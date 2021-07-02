using System;

namespace PlusOne
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(",",PlusOne(new int[]{ 9,9,9})));
        }

        static int[] PlusOne(int[] digits)
        {
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                digits[i]++;
                digits[i] = digits[i] % 10;
                if(digits[i] != 0) return digits;
            }

            digits = new int[digits.Length + 1  ];
            digits[0] = 1;
            return digits;
        }
    }
}
