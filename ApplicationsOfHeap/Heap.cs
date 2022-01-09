using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsOfHeap
{
    public class Heap
    {
        private const int Capacity = 32;
        private int Count;
        private int[] arr;
        private bool isMinHeap;

        public Heap(bool isMin = true)
        {
            arr = new int[Capacity];
            Count = 0;
            isMinHeap = isMin;
        }
        private void ProclateDown(int parent)
        {
            int lChild = 2 * parent + 1;
            int rChild = lChild + 1;
            int child = -1;
            int temp;

            if (lChild < Count)
            {
                child = lChild;
            }
            if (rChild < Count && compare(arr, lChild, rChild))
            {
                child = rChild;
            }
            if (child != -1 && compare(arr, parent, child))
            {
                temp = arr[parent];
                arr[parent] = arr[child];
                arr[child] = temp;
                ProclateDown(child);
            }
        }
        private void ProclateUp(int child)
        {
            int parent = (child - 1) / 2;
            int temp;
            if (parent < 0)
                return;

            if (compare(arr, parent, child))
            {
                temp = arr[child];
                arr[child] = arr[parent];
                arr[parent] = temp;
                ProclateUp(parent);
            }
        }
        private bool compare(int[] arr, int first, int second)
        {
            if (isMinHeap)
                return (arr[first] - arr[second]) > 0;//min heap
            else
                return (arr[first] - arr[second]) < 0;//max heap
        }
        public Heap(int[] array, bool isMin = true)
        {
            Count = array.Length;
            arr = array;
            isMinHeap = isMin;
            //build heap over array
            for (int i = (Count/2); i >= 0; i--)
            {
                ProclateDown(i);
            }
        }
        public bool isEmpty()
        {
            return Count == 0;
        }
        public int size()
        {
            return Count;
        }
        public int peek()
        {
            if (Count == 0)
                throw new System.InvalidOperationException();
            return arr[0];
        }
    }
    
}
