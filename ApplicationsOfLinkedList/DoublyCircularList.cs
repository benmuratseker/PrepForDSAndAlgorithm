using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsOfLinkedList
{
    public class DoublyCircularList
    {
        private Node head = null;
        private Node tail = null;
        private int count = 0;
        private class Node
        {
            internal int value;
            internal Node next;
            internal Node prev;

            public Node(int v, Node nxt, Node prv)
            {
                value = v;
                next = nxt;
                prev = prv;
            }
            public Node(int v)
            {
                value = v;
                next = this;
                prev = this;
            }
        }

        public void addHead(int val)
        {
            Node newNode = new Node(val, null, null);
            if (count == 0)
            {
                tail = head = newNode;
                newNode.next = newNode;
                newNode.prev = newNode;
            }
            else
            {
                newNode.next = head;
                newNode.prev = head.prev;
                head.prev = newNode;
                newNode.prev.next = newNode;
                head = newNode;
            }
            count++;
        }
        public void addTail(int val)
        {
            Node newNode = new Node(val, null, null);
            if (count ==0)
            {
                head = tail = newNode;
                newNode.next = newNode;
                newNode.prev = newNode;
            }
            else
            {
                newNode.next = tail.next;
                newNode.prev = tail;
                tail.next = newNode;
                newNode.next.prev = newNode;
                tail = newNode;
            }
            count++;
        }
        public int removeHead()
        {
            if (count == 0)
                throw new InvalidOperationException("empty list");

            int val = head.value;
            count--;
            if (count == 0)
            {
                head = null;
                tail = null;
                return val;
            }
            Node next = head.next;
            next.prev = tail;
            tail.next = next;
            head = next;
            return val;
        }
        public int removeTail()
        {
            if (count == 0)
                throw new InvalidOperationException("empty list");

            int val = tail.value;
            count--;

            if (count == 0)
            {
                head = null;
                tail = null;
                return val;
            }
            Node prev = tail.prev;
            prev.next = head;
            head.prev = prev;
            tail = prev;
            return val;
        }
    }
}
