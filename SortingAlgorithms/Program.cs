using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] array = new int[] { 6, 4, 5, 1, 8, 2, 9, 7, 10, 3 };
            int[] array = new int[] { 2, 6, 3, 5, 1, 4 };
            int[] bucketArray = new int[] { 2, 6, 4, 1, 5, 8, 1, 4, 6, 1 };

            //int[] array = new int[] { 9, 1, 8, 2, 7, 3, 6, 4, 5 };
            //int[] array = new int[] { 4,3,1,2,7,5 }; 
            //Sort.BubbleSort(array);
            Sort.InsertionSort(array);
            //Sort.SelectionSort(array);
            //Sort.MergeSort(array,0,array.Length-1);
            //Sort.QuickSort(array, 0, array.Length - 1);
            //Sort.BucketSort(bucketArray, 0, 10);
            //Print(bucketArray);
            Print(array);
        }

        static void Print(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}
