using System;

namespace LatestTimeByReplacingHiddenDigits
{
    /// <summary>
    /// 替换隐藏数字得到的最晚时间
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MaximumTime("2?:?0"));
        }

        static string MaximumTime(string time)
        {
            var arr = time.ToCharArray();
            if(arr[0] == '?')
            {
                arr[0] = ('4' <= arr[1] && arr[1] <= '9') ? '1' : '2';
            }

            if(arr[1] == '?')
            {
                arr[1] = arr[0] == '2' ? '3' : '9';
            }

            if(arr[3] == '?')
            {
                arr[3] = '5';
            }

            if(arr[4] == '?')
            {
                arr[4] = '9';
            }
            return string.Join("", arr);
        }
    }
}
