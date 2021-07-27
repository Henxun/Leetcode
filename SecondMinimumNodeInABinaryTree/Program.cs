using System;

namespace SecondMinimumNodeInABinaryTree
{
    class Program
    {
        static int ans = -1;
        static int rootValue;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static void DFS(TreeNode node)
        {
            if(node == null)
            {
                return;
            }

            if(ans != -1 && node.val >= ans)
            {
                return;
            }

            if(node.val > rootValue)
            {
                ans = node.val;
            }

            DFS(node.left);
            DFS(node.right);
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}
