using System;

namespace CommonNode
{
    /// <summary>
    /// 输入两个链表，找出它们的第一个公共节点。
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static ListNode getIntersectionNode(ListNode headA, ListNode headB)
        {
            ListNode p1 = headA, p2 = headB;
            while(p1 != p2)
            {
                p1 = p1 == null ? headB : p1.next;
                p2 = p2 == null ? headA : p2.next;
            }
            return p1;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
}
