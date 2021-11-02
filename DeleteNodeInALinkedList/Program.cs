using System;

namespace DeleteNodeInALinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static void DeleteNode(ListNode node)
        {
            node.val = node.next.val;
            node.next = node.next.next;
        }

        public class ListNode
        {
            public int val { get; set; }
            public ListNode next { get; set; }
            public ListNode(int val)
            {
                this.val = val;
            }
        }
    }
}
