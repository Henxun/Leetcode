using System;
using System.Collections.Generic;

namespace LongestWordInDictionaryThroughDeleting
{
    //给你一个字符串 s 和一个字符串数组 dictionary 作为字典，找出并返回字典中最长的字符串，该字符串可以通过删除 s 中的某些字符得到。
    //如果答案不止一个，返回长度最长且字典序最小的字符串。如果答案不存在，则返回空字符串。
    class Program
    {
        static void Main(string[] args)
        {
            string s = "abpcplea";
            IList<string> dictionary = new List<string> { "ale", "apple", "monkey", "plea" };
            Console.WriteLine(FindLongestWord(s, dictionary));
        }

        static string FindLongestWord(string s, IList<string> dictionary)
        {
            string res = string.Empty;

            foreach (var t in dictionary)
            {
                int i = 0, j = 0;

                while(i < t.Length && j < s.Length)
                {
                    if(t[i] == s[j])
                    {
                        i++;
                        j++;
                    }
                    else
                    {
                        j++;
                    }
                }

                if(i == t.Length)
                {
                    if (t.Length > res.Length || (t.Length == res.Length && t.CompareTo(res) > 0))
                        res = t;
                }
            }
            return res;
        }
    }
}
