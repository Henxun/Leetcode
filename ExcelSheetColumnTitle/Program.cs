using System;
using System.Text;

namespace ExcelSheetColumnTitle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ConvertToTitle(701)); 
        }

        static string ConvertToTitle(int columnNumber)
        {
            StringBuilder sb = new StringBuilder();
            while(columnNumber > 0)
            {
                columnNumber--;
                sb.Insert(0,(char)(columnNumber % 26 + 'A'));
                columnNumber /= 26;
            }
            return sb.ToString();
        }
    }
}
