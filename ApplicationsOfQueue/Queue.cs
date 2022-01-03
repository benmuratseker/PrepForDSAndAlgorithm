using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsOfQueue
{
    public class Queue
    {
        private int count;
        private int capacity = 100;
        private int[] data;
        internal int front = 0;
        internal int back = 0;
        public Queue()
        {
            count = 0;
            data = new int[capacity];
        }
        public bool Add(int value)
        {
            if (count >= capacity)
            {
                Console.WriteLine("queue is full");
                return false;
            }
            else
            {
                count++;
                data[back] = value;
                back = (++back) % (capacity - 1);
            }
            return true;
        }
        public int Remove()
        {
            int val;
            if(count <= 0)
            {
                Console.WriteLine("queue is empty");
                return -1;
            }
            else
            {
                count--;
                val = data[front];
                front = (++front) % (capacity - 1);
            }
            return val;
        }
        internal bool Empty
        {
            get
            {
                return count == 0;
            }
        }
        internal int Size()
        {
            return count;
        }
        public void Print()
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(data[i]);
            }
        }
    }
}
