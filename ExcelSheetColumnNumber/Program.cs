using System;

namespace ExcelSheetColumnNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(TitleToNumber("AA"));
        }

        static int TitleToNumber(string columnTitle)
        {
            int length = columnTitle.Length, pow = 1, result = 0;

            for(int i = length - 1; i >= 0; i--)
            {
                int num = columnTitle[i] - 'A' + 1;
                result += num * pow;
                pow *= 26;
            }

            return result;
            
        }
    }
}
