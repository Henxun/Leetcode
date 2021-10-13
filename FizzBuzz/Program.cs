using System;
using System.Collections.Generic;
using System.Text;

namespace FizzBuzz
{
    /// <summary>
    /// 
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static IList<string> FizzBuzz(int n)
        {
            IList<string> list = new List<string>();
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= n; i++)
            {
                if(i % 3 == 0)
                {
                    sb.Append("Fizz");
                }

                if(i % 5 == 0)
                {
                    sb.Append("Buzz");
                }

                if(sb.Length == 0)
                {
                    sb.Append(i);
                }

                list.Add(sb.ToString());
                sb.Clear();
            }
            return list;
        }
    }
}
