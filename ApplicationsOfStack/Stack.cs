using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsOfStack
{
    public class Stack
    {
        private int capacity = 100;
        private int[] data;
        private int top = -1;
        
        public Stack()
        {
            data = new int[capacity];
        }
        public Stack(int size)
        {
            data = new int[size];
            capacity = size;
        }
        public bool Empty()
        {
            return (top == -1);
        }
        public int Size()
        {
            return (top + 1);
        }
        public void Print()
        {
            for (int i = top; i > -1; i--)
            {
                Console.WriteLine(data[i]);
            }
        }
        public void Push(int value)
        {
            if (Size() == data.Length)
                throw new InvalidOperationException("stack overflow exception");

            top++;
            data[top] = value;
        }
        public int Pop()
        {
            if (Empty())
                throw new InvalidOperationException("stack empty exception");

            int topVal = data[top];
            top--;
            return topVal;
        }
        public int Peek()
        {
            if (Empty())
                throw new InvalidOperationException("stack empty exception");
            return data[top];
        }

    }
}
