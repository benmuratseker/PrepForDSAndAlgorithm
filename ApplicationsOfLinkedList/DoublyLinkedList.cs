using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsOfLinkedList
{
    public class DoublyLinkedList
    {
        private Node head;
        private Node tail;
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
                prev = null;
                next = null;
            }
        }

        public void addHead(int val)
        {
            Node newNode = new Node(val, null, null);
            if (head == null)
            {
                tail = head = newNode;
            }
            else
            {
                head.prev = newNode;
                newNode.next = head;
                head = newNode;
            }
            count++;
        }
        public void sortedInsert(int val)
        {
            Node temp = new Node(val);
            Node curr = head;
            if (curr == null)
            {
                tail = temp;
                head = temp;
            }
            if (head.value <= val)//first element
            {
                temp.next = head;
                head.prev = temp;
                head = temp;
            }
            while (curr.next !=null && curr.next.value > val)//traversal
            {
                curr = curr.next;
            }
            if (curr.next == null)//at the end
            {
                tail = temp;
                temp.prev = curr;
                curr.next = temp;
            }
            else
            {
                temp.next = curr.next;
                temp.prev = curr;
                curr.next = temp;
                temp.next.prev = temp;
            }
        }
        public int removeHead()
        {
            if (count == 0)
                throw new InvalidOperationException("list is empty");

            int val = head.value;
            head = head.next;
            if (head == null)
            {
                tail = null;
            }
            else
            {
                head.prev = null;
            }
            count--;
            return val;
        }
        public bool removeNode(int val)
        {
            Node curr = head;
            if (curr == null)//empty
            {
                return false;
            }
            if (curr.value == val)//head is the node with the val
            {
                head = head.next;
                count--;
                if (head != null)
                    head.prev = null;
                else
                    tail = null;//only one element in list
                return true;
            }
            while (curr.next != null)
            {
                if (curr.next.value == val)
                {
                    curr.next = curr.next.next;
                    if (curr.next == null)//last element
                        tail = curr;
                    else
                        curr.next = curr;
                    count--;
                    return true;
                }
                curr = curr.next;
            }
            return false;
        }
        public void removeDuplicate()
        {
            Node curr = head;
            Node deleteMe;
            while (curr != null)
            {
                if (curr.next != null && curr.value == curr.next.value)
                {
                    deleteMe = curr.next;
                    curr.next = deleteMe.next;
                    curr.next.prev = curr;
                    if (deleteMe == tail)
                        tail = curr;
                }
                else
                    curr = curr.next;
            }
        }
        public void reverseList()
        {
            Node curr = head;
            Node tempNode;
            while (curr != null)
            {
                tempNode = curr.next;
                curr.next = curr.prev;
                curr.prev = tempNode;
                if (curr.prev == null)
                {
                    tail = head;
                    head = curr;
                    return;
                }
                curr = curr.prev;
            }
            return;
        }
    }
}
