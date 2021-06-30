using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LCOF
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode treeNode = new TreeNode(1);
            treeNode.left = new TreeNode(2);
            treeNode.right = new TreeNode(3)
            {
                left = new TreeNode(4),
                right = new TreeNode(5)
            };

            string s = Serialize(treeNode);
            TreeNode node = Desrialize(s);
            Console.WriteLine(s);            
        }

        static string Serialize(TreeNode root)
        {
            IList<string> sb = new List<string>();
            Serialize(sb, root);
            return string.Join(",", sb);
        }

        static void Serialize(IList<string> result, TreeNode root)
        {
            if(root == null)
            {
                result.Add("null");
                return;
            }    
            result.Add(root.val.ToString());
            Serialize(result, root.left);
            Serialize(result, root.right);
        }

        static TreeNode Desrialize(string data)
        {
            var queue = new Queue<string>(data.Split(","));
            return Desrialize(queue);
        }

        static TreeNode Desrialize(Queue<string> queue)
        {
            var data = queue.Dequeue();
            if(data.Equals("null"))
            {
                return null;
            }

            TreeNode root = new TreeNode(int.Parse(data));
            root.left = Desrialize(queue);
            root.right = Desrialize(queue);
            return root;
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x)
            {
                val = x;
            }
        }
    }
}
