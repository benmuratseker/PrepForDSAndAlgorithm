using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsOfLinkedList
{
    public class CircularLinkedList
    {
        private Node tail;
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
        public void addHead(int val)
        {
            Node temp = new Node(val, null);
            if (count == 0)
            {
                tail = temp;
                temp.next = temp;
            }
            else
            {
                temp.next = tail.next;
                tail.next = temp;
            }
            count++;
        }
        public void addTail(int val)
        {
            Node temp = new Node(val, null);
            if (count == 0)
            {
                tail = temp;
                tail.next = temp;
            }
            else
            {
                temp.next = tail.next;
                tail.next = temp;
                tail = temp;
            }
            count++;
        }
        public bool searchList(int data)
        {
            Node temp = tail;
            for (int i = 0; i < count; i++)
            {
                if (temp.value == data)
                    return true;
                temp = temp.next;
            }
            return false;
        }
        public void print()
        {
            if (count == 0)
                return;

            Node temp = tail.next;
            while (temp != tail)
            {
                Console.Write(temp.value + " ");
                temp = temp.next;
            }
            Console.Write(temp.value);
        }
        public int removeHead()
        {
            if (count == 0)
                throw new InvalidOperationException("empty list");
            int val = tail.next.value;
            if (tail == tail.next)
                tail = null;
            else
                tail.next = tail.next.next;

            count--;
            return val;
        }
        public bool removeNode(int val)
        {
            if (count == 0)
                throw new InvalidOperationException("empty list");

            Node prev = tail;
            Node curr = tail.next;
            Node head = tail.next;
            if (curr.value == val)//head and single node case
            {
                if (curr == curr.next)//single node case
                {
                    tail = null;
                }
                else//head case
                {
                    tail.next = tail.next.next;
                }
                return true;
            }
            prev = curr;
            curr = curr.next;
            while (curr != head)
            {
                if (curr.value == val)
                {
                    if (curr == tail)
                    {
                        tail = prev;
                    }
                    prev.next = curr.next;
                    return true;
                }
                prev = curr;
                curr = curr.next;
            }
            return false;
        }
        public void deleteList()
        {
            tail = null;
            count = 0;
        }
    }
}
