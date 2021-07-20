using System;
using System.Collections.Generic;

namespace MergeTwoLists
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string s = null;
            var splits = Split(s, ',');
            Console.WriteLine(string.Join(" ", splits));
        }

        static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {           
            ListNode result = new ListNode(0), cur = result;
            while(l1 != null && l2 != null)
            {
                if(l1.val < l2.val)
                {
                    cur.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    cur.next = l2;
                    l2 = l2.next;
                }
            }
            cur.next = l1 != null ? l1 : l2;
            return result;
            
        }

        static string[] Split(string s, char split)
        {

            if (s == null)
                throw new ArgumentNullException();

            int startIndex = 0;
            List<string> result = new List<string>();
            for(int i = 0; i< s.Length; i++)
            {
                if(s[i] == split)
                {
                    result.Add(s.Substring(startIndex, i - startIndex));
                    startIndex = i + 1;
                }
            }

            if(startIndex < s.Length)
            {
                result.Add(s.Substring(startIndex, s.Length - startIndex));
            }
            return result.ToArray();
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
