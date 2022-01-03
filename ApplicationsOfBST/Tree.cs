using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsOfBST
{
    public class Tree
    {
        private Node root;
        private class Node
        {
            internal int value;
            internal Node lChild;
            internal Node rChild;
            public Node(int v)
            {
                value = v;
                lChild = null;
                rChild = null;
            }
            public Node(int v, Node l, Node r)
            {
                value = v;
                lChild = l;
                rChild = r;
            }
        }
        public Tree()
        {
            root = null;
        }
        public void levelOrderBinaryTree(int[] arr)
        {
            root = levelOrderBinaryTree(arr, 0);
        }
        private Node levelOrderBinaryTree(int[] arr, int start)
        {
            int size = arr.Length;
            Node curr = new Node(arr[start]);

            int left = 2 * start + 1;
            int right = 2 * start + 2;
            if (left < size)
                curr.lChild = levelOrderBinaryTree(arr, left);
            if (right < size)
                curr.rChild = levelOrderBinaryTree(arr, right);

            return curr;
        }

        //PreOrder: Root, Left, Right
        public void PrintPreOrder()
        {
            PrintPreOrder(root);
        }

        private void PrintPreOrder(Node node)
        {
            if (node != null)
            {
                Console.Write(" " + node.value);
                PrintPreOrder(node.lChild);
                PrintPreOrder(node.rChild);
            }
        }
        //PostOrder: Left, Right, Root
        public void PrintPostOrder()
        {
            PrintPostOrder(root);
        }

        private void PrintPostOrder(Node node)
        {
            if (node != null)
            {
                PrintPostOrder(node.rChild);
                PrintPostOrder(node.lChild);
                Console.Write(" " + node.value);
            }
        }

        //InOrder: Left, Root, Right
        public void PrintInOrder()
        {
            PrintInOrder(root);
        }

        private void PrintInOrder(Node node)
        {
            if (node != null)
            {
                PrintInOrder(node.lChild);
                Console.Write(" " + node.value);
                PrintInOrder(node.rChild);
            }
        }

        //Level Order: Breadth First Traversal
        public void PrintBreadthFirst()
        {
            Queue<Node> que = new Queue<Node>();
            Node temp;

            if (root != null)
                que.Enqueue(root);
            while (que.Count != 0)
            {
                temp = que.Dequeue();
                Console.Write(" " + temp.value);

                if (temp.lChild != null)
                {
                    que.Enqueue(temp.lChild);
                }
                if (temp.rChild != null)
                {
                    que.Enqueue(temp.rChild);
                }
            }
        }

        //Depth First Search
        public void PrintDepthFirst()
        {
            Stack<Node> stk = new Stack<Node>();
            Node temp;

            if (root != null)
                stk.Push(root);

            while (stk.Count != 0)
            {
                temp = stk.Pop();
                Console.WriteLine(temp.value);

                if (temp.lChild != null)
                {
                    stk.Push(temp.lChild);
                }
                if (temp.rChild != null)
                {
                    stk.Push(temp.rChild);
                }
            }
        }

        //Nth Pre-Order
        public void NthPreOrder(int index)
        {
            int[] counter = new int[] { 0 };
            NthPreOrder(root, index, counter);
        }
        private void NthPreOrder(Node node, int index, int[] counter)
        {
            if (node != null)
            {
                counter[0]++;
                if (counter[0] == index)
                    Console.Write(node.value);
                NthPreOrder(node.lChild, index, counter);
                NthPreOrder(node.rChild, index, counter);
            }
        }

        //Nth Post-Order
        public void NthPostOrder(int index)
        {
            int[] counter = new int[] { 0 };
            NthPostOrder(root, index, counter);
        }
        private void NthPostOrder(Node node, int index, int[] counter)
        {
            if (node != null)
            {
                NthPostOrder(node.lChild, index, counter);
                NthPostOrder(node.rChild, index, counter);
                counter[0]++;
                if (counter[0] == index)
                {
                    Console.Write(" " + node.value);
                }
            }
        }

        //Nth In-Order
        public void NthInOrder(int index)
        {
            int[] counter = new int[] { 0 };
            NthInOrder(root, index, counter);
        }
        private void NthInOrder(Node node, int index, int[] counter)
        {
            if (node != null)
            {
                NthInOrder(node.lChild, index, counter);
                counter[0]++;
                if (counter[0] == index)
                {
                    Console.Write(" " + node.value);
                }
                NthInOrder(node.rChild, index, counter);
            }
        }

        //Print all paths from root to the leaf
        public void PrintAllPath()
        {
            Stack<int> stk = new Stack<int>();
            PrintAllPath(root, stk);
        }
        private void PrintAllPath(Node curr, Stack<int> stk)
        {
            if (curr == null)
                return;

            stk.Push(curr.value);

            if (curr.lChild == null && curr.rChild == null)
            {
                foreach (int val in stk)
                {
                    Console.Write(val + " ");
                }
                Console.WriteLine();
                stk.Pop();
                return;
            }

            PrintAllPath(curr.rChild, stk);
            PrintAllPath(curr.lChild, stk);
            stk.Pop();
        }

        //Total number of nodes in BT
        public int NumNodes()
        {
            return NumNodes(root);
        }
        private int NumNodes(Node curr)
        {
            if (curr == null)
            {
                return 0;
            }
            else
            {
                return (1 + NumNodes(curr.rChild) + NumNodes(curr.lChild));
            }
        }

        //Sum of all nodes in a BT
        public int SumAllBT()
        {
            return SumAllBT(root);
        }
        private int SumAllBT(Node curr)
        {
            if (curr != null)
                return 0;

            return (curr.value + SumAllBT(curr.lChild) + SumAllBT(curr.rChild));
        }

        //Number of leaf nodes in Binary Tree
        public int NumLeafNodes()
        {
            return NumLeafNodes(root);
        }
        private int NumLeafNodes(Node curr)
        {
            if (curr == null)
                return 0;
            if (curr.lChild == null && curr.rChild == null)
                return 1;
            else
                return (NumLeafNodes(curr.rChild) + NumLeafNodes(curr.lChild));
        }

        //Number of Full Nodes in a Binary Tree
        public int NumberOfFullNodes()
        {
            return NumberOfFullNodes(root);
        }
        private int NumberOfFullNodes(Node curr)
        {
            if (curr == null)
                return 0;
            if (curr.lChild == null && curr.rChild == null)
                return 1;
            else
                return (NumberOfFullNodes(curr.rChild) + NumberOfFullNodes(curr.lChild));
        }

        //Search value in a Binary Tree
        public bool SearchBT(int val)
        {
            return SearchBT(root, val);
        }
        private bool SearchBT(Node curr, int val)
        {
            bool left, right;
            if (curr == null)
                return false;

            if (curr.value == val)
                return true;

            left = SearchBT(curr.lChild, val);
            if (left)
                return true;

            right = SearchBT(curr.rChild, val);
            if (right)
                return true;

            return false;
        }

        //Find Max in Binary Tree
        public int FindMaxBT()
        {
            int ans = FindMaxBT(root);
            return ans;
        }
        private int FindMaxBT(Node curr)
        {
            int left, right;
            if (curr == null)
                return int.MinValue;

            int max = curr.value;
            left = FindMaxBT(curr.lChild);
            right = FindMaxBT(curr.rChild);

            if (left > max)
                max = left;
            if (right > max)
                max = right;

            return max;
        }

        //Find Depth of the Binary Tree
        public int TreeDepth()
        {
            return TreeDepth(root);
        }
        private int TreeDepth(Node curr)
        {
            if (curr == null)
                return 0;
            else
            {
                int lDepth = TreeDepth(curr.lChild);
                int rDepth = TreeDepth(curr.rChild);

                if (lDepth > rDepth)
                    return lDepth + 1;
                else
                    return rDepth + 1;
            }
        }

        //Find max path length of Binary Tree
        public int MaxLengthPathBT()
        {
            return MaxLengthPathBT(root);
        }
        private int MaxLengthPathBT(Node curr)
        {
            int max;
            int leftPath, rightPath;
            int leftMax, rightMax;
            if (curr == null)
                return 0;

            leftPath = TreeDepth(curr.lChild);
            rightPath = TreeDepth(curr.rChild);

            max = leftPath + rightPath + 1;

            leftMax = MaxLengthPathBT(curr.lChild);
            rightMax = MaxLengthPathBT(curr.rChild);

            if (leftMax > max)
                max = leftMax;

            if (rightMax > max)
                max = rightMax;

            return max;
        }

        //Identical Binary Trees
        public bool IsEqual(Tree T2)
        {
            return IsEqualUtil(root, T2.root);
        }
        private bool IsEqualUtil(Node node1, Node node2)
        {
            if (node1 == null && node2 == null)
                return true;
            else if (node1 == null || node2 == null)
                return false;
            else
                return (IsEqualUtil(node1.lChild, node2.lChild) && IsEqualUtil(node1.rChild, node2.rChild) && (node1.value == node2.value));
        }

        //Copy Binary Tree
        public Tree CopyTree()
        {
            Tree tree2 = new Tree();
            tree2.root = CopyTree(root);
            return tree2;
        }
        private Node CopyTree(Node curr)
        {
            Node temp;
            if (curr != null)
            {
                temp = new Node(curr.value);
                temp.lChild = CopyTree(curr.lChild);
                temp.rChild = CopyTree(curr.rChild);
                return temp;
            }
            else
                return null;
        }

        //Is Complete Binary Tree: Sol ve sağ node varsa complete tree dir
        public bool IsCompleteTree()
        {
            Queue<Node> queue = new Queue<Node>();
            Node temp = null;
            int noChild = 0;
            if (root != null)
                queue.Enqueue(root);

            while (queue.Count != 0)
            {
                temp = queue.Dequeue();
                if (temp.lChild != null)
                {
                    if (noChild == 1)
                        return false;

                    queue.Enqueue(temp.lChild);
                }
                else
                    noChild = 1;

                if (temp.rChild != null)
                {
                    if (noChild == 1)
                        return false;

                    queue.Enqueue(temp.rChild);
                }
                else
                    noChild = 1;
            }
            return true;
        }

        //Binary Tree is a Heap: complete tree mi ve parent node left ve right child value suna küçük veya eşit mi
        public bool IsHeap()
        {
            return IsHeap(root);
        }
        private bool IsHeap(Node curr)
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(curr);
            bool isNull = false;

            while (queue.Count != 0)
            {
                Node temp = queue.Peek();
                queue.Dequeue();

                if (temp.lChild != null)
                {
                    if (isNull || temp.lChild.value >= temp.value)
                        return false;
                    queue.Enqueue(temp.lChild);
                }
                else
                    isNull = true;

                if (temp.rChild != null)
                {
                    if (isNull || temp.rChild.value >= temp.value)
                        return false;
                    queue.Enqueue(temp.rChild);
                }
                else
                    isNull = true;
            }
            return true;
        }

        //Binary Search Tree Applications: tüm binary tree algoritmaları bimary search tree için de geçerlidir
        //soldaki node parent node dan küçük, sağdaki node parent node dan daha büyük değere sahiptir ve tekrarlı değer olamaz

        public void CreateBinaryTree(int[] arr)
        {
            root = CreateBinaryTree(arr, 0, arr.Length - 1);
        }
        private Node CreateBinaryTree(int[] arr, int start, int end)
        {
            Node curr = null;
            if (start > end)
                return null;
            //ortadaki değer root olarak belirlenir ve buna göre sol sağ child lar belirlenir.
            int mid = (start + end) / 2;
            curr = new Node(arr[mid]);
            curr.lChild = CreateBinaryTree(arr, start, mid - 1);
            curr.rChild = CreateBinaryTree(arr, mid + 1, end);
            return curr;
        }
    }
}
