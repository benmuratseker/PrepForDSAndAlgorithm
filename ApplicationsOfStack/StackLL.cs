using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsOfStack
{
    public class StackLL
    {
        private Node head = null;
        private int count = 0;
        private class Node
        {
            internal int value;
            internal Node next;
            public Node(int v, Node n)
            {
                value = v;
                next = n;
            }
        }
        public int Size()
        {
            return count;
        }
        public bool Empty
        {
            get
            {
                return count == 0;
            }
        }
        public int Peek()
        {
            if (Empty)
                throw new InvalidOperationException("stack empty");
            return head.value;
        }
        public void Push(int val)
        {
            head = new Node(val, head);
            count++;
        }
        public int Pop()
        {
            if (Empty)
                throw new InvalidOperationException("stack empty");
            int val = head.value;
            head = head.next;
            count--;
            return val;
        }
        public void InsertAtBottom(int val)
        {
            if (Empty)
                Push(val);
            else
            {
                int temp = Pop();
                InsertAtBottom(val);
                Push(temp);
            }
        }
        public void Print()
        {
            Node temp = head;
            while (temp != null)
            {
                Console.WriteLine(temp.value);
                temp = temp.next;
            }
        }
    }
}
