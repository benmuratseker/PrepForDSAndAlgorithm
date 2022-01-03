using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsOfLinkedList
{
    public class NodeList
    {
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
        private Node head;
        internal int count;
        public void addHead(int val)
        {
            head = new Node(val, head);
            count++;
        }
        public void addTail(int val)
        {
            Node newNode = new Node(val, null);
            Node curr = head;

            if (head == null)
            {
                head = newNode;
            }
            while (curr.next != null)
            {
                curr = curr.next;
            }
            curr.next = newNode;
        }
        public void print()
        {
            Node temp = head;
            while (temp != null)
            {
                Console.Write(temp.value + " ");
                temp = temp.next;
            }
        }
        public void sortedInsert(int val)
        {
            Node newNode = new Node(val, null);
            Node curr = head;

            if(curr == null || curr.value > val)
            {
                newNode.next = head;
                head = newNode;
                return;
            }
            while (curr.next != null && curr.next.value < val)
            {
                curr = curr.next;
            }

            newNode.next = curr.next;
            curr.next = newNode;
        }
        public bool searchList(int val)
        {
            Node temp = head;
            while (temp != null)
            {
                if (temp.value == val)
                {
                    return true;
                }
                temp = temp.next;
            }
            return false;
        }
        public int removeHead()
        {
            if (count == 0)
                throw new InvalidOperationException("empty list");

            int value = head.value;
            head = head.next;
            count--;
            return value;
        }
        public bool deleteNode(int val)
        {
            Node temp = head;
            if (count == 0)
                return false;
            if(val == head.value)
            {
                head = head.next;
                count--;
                return true;
            }
            while (temp.next != null)
            {
                if(temp.next.value == val)
                {
                    temp.next = temp.next.next;
                    count--;
                    return true;
                }
                temp = temp.next;
            }
            return false;
        }
        public void deleteNodes(int val)
        {
            Node curr = head;
            Node nextNode;
            while (curr != null && curr.value == val)
            {
                head = curr.next;
                curr = head;
            }
            while (curr != null)
            {
                nextNode = curr.next;
                if (nextNode != null && nextNode.value
                     == val)
                    curr.next = nextNode.next;
                else
                    curr = nextNode;
            }
        }
        public void deleteList()
        {
            head = null;
            count = 0;
        }
        public void reverse()
        {
            Node curr = head;
            Node prev = null;
            Node next = null;
            while (curr != null)
            {
                next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }
            head = prev;
        }
        public void removeDuplicate()
        {
            Node curr = head;
            while (curr != null)
            {
                if (curr.next != null && curr.value == curr.next.value)
                {
                    curr.next = curr.next.next;
                }
                else
                {
                    curr = curr.next;
                }
            }
        }
        public int findLength()
        {
            Node curr = head;
            count = 0;
            while (curr!= null)
            {
                count++;
                curr = curr.next;
            }
            return count;
        }
        public bool loopDetect()
        {
            Node slowPtr;
            Node fastPtr;
            slowPtr = fastPtr = head;

            while (fastPtr.next != null && fastPtr.next.next !=null)
            {
                //if(head == fastPtr.next || head == fastPtr.next.next) bu circular loop olduğu anlamına gelir

                slowPtr = slowPtr.next;
                fastPtr = fastPtr.next.next;
                if(slowPtr == fastPtr)
                {
                    Console.WriteLine("loop found"); ;
                    return true;
                    //return slowPtr denirse loop noktası belirlenmiş olur ve 
                }
            }
            Console.WriteLine("loop not found"); ;
            return false;
        }
    }
   
}
