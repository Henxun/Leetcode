using System;

namespace SplitLinkedListInParts
{
    //给你一个头结点为 head 的单链表和一个整数 k ，请你设计一个算法将链表分隔为 k 个连续的部分。
    //每部分的长度应该尽可能的相等：任意两部分的长度差距不能超过 1 。这可能会导致有些部分为 null 。
    //这 k 个部分应该按照在链表中出现的顺序排列，并且排在前面的部分的长度应该大于或等于排在后面的长度。
    //返回一个由上述 k 部分组成的数组。
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        ListNode[] SplitListToParts(ListNode head, int k)
        {
            ListNode tmp = head;
            int count = 0;
            while(tmp != null)
            {
                count++;
                tmp = tmp.next;
            }

            int perCount = count / k;
            int mod = count % k;

            ListNode[] result = new ListNode[k];

            ListNode current = head;
            for (int i = 0; i < k && current != null; i++)
            {
                result[i] = current;
                int size = perCount + (i < mod ? 1 : 0);
                for(int j = 1; j < size; j++)
                {
                    current = current.next;
                }

                ListNode next = current.next;
                current.next = null;
                current = next;
            }

            return result;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
