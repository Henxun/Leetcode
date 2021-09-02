using System;

namespace TheListInTheBottomPartKNodes
{
    //输入一个链表，输出该链表中倒数第k个节点。为了符合大多数人的习惯，本题从1开始计数，即链表的尾节点是倒数第1个节点。
    //例如，一个链表有 6 个节点，从头节点开始，它们的值依次是 1、2、3、4、5、6。这个链表的倒数第 3 个节点是值为 4 的节点。
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        ListNode GetKthFromEnd(ListNode head, int k)
        {
            int n = 0;
            ListNode current = head;
            for(;current!=null;current=current.next)
            {
                n++;
            }

            for(current = head; n > k; n--)
            {
                current = current.next;
            }
            return current;

        }

        ListNode GetKthFromEndTwoPoint(ListNode head, int k)
        {
            ListNode fast = head, slow = head;

            while(fast != null && k > 0)
            {
                fast = fast.next;
                k--;
            }

            while(fast != null)
            {
                fast = fast.next;
                slow = slow.next;
            }

            return slow;

        }
    }

    public class ListNode
    {
         public int val;
         public ListNode next;
         public ListNode(int x) { val = x; }
     }
}
