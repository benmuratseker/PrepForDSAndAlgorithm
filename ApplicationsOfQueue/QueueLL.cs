using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsOfQueue
{
    public class QueueLL
    {
        private Node tail = null;
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
        public void Add(int val)
        {
            Node temp = new Node(val, null);
            if (tail == null)
            {
                tail = temp;
                tail.next = tail;
            }
            else
            {
                temp.next = tail.next;
                tail.next = temp;
                tail = temp;
            }
            count++;
        }
        public int Remove()
        {
            if (Empty)
                throw new InvalidOperationException("queue is empty");
            else
            {
                int val = 0;
                if (tail ==tail.next)//single elemen
                {
                    val = tail.value;
                    tail = null;
                }
                else
                {
                    val = tail.next.value;
                    tail.next = tail.next.next;
                }
                count--;
                return val;
            }
        }
        public int Peek()
        {
            if (Empty)
                throw new InvalidOperationException("queue is empty");

            int val;
            if (tail == tail.next)//single element
            {
                val = tail.value;
            }
            else
            {
                val = tail.next.value;
            }
            return val;
        }
        public void Print()
        {
            for (int i = -1; i <= count; i++)
            {
                Console.WriteLine(Remove());
            }
        }
    }
}
