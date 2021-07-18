using System;
using System.Collections.Generic;
using System.Text;

namespace GroupAnagramsLCCI
{
    /// <summary>
    /// 编写一种方法，对字符串数组进行排序，将所有变位词组合在一起。变位词是指字母相同，但排列不同的字符串。
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var lst = GroupAnagrams(new string[] { "eat", "tea", "tan", "ate", "nat", "bat" });
            for (int i = 0; i < lst.Count; i++)
            {
                Console.WriteLine(string.Join("\t", lst[i]));
            }
        }

        static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            IDictionary<string, IList<string>> dic = new Dictionary<string, IList<string>>();
            foreach (string s in strs)
            {
                int[] counts = new int[26];
                for (int i = 0; i < s.Length; i++)
                {
                    counts[s[i] - 'a'] ++;
                }

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < 26; i++)
                {
                    if(counts[i] != 0)
                    {
                        sb.Append((char)(i + 'a'));
                        sb.Append(counts[i]);
                    }
                }

                if(dic.ContainsKey(sb.ToString()))
                {
                    dic[sb.ToString()].Add(s);
                }
                else
                {
                    dic.Add(sb.ToString(), new List<string> { s });
                }
            }
            return new List<IList<string>>(dic.Values);
        }
    }
}
