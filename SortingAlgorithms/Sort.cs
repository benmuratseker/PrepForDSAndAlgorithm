using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    public static class Sort
    {
        static bool More(int val1, int val2)
        {
            return val1 > val2;
        }
        static void Swap(int[] arr, int index1, int index2)
        {
            int temp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = temp;
        }
        public static void BubbleSort(int[] arr)
        {
            int size = arr.Length;

            for (int i = 0; i < size - 1; i++)
            {
                for (int j = 0; j < size - i - 1; j++)
                {
                    if (More(arr[j], arr[j + 1]))
                        Swap(arr, j, j + 1);
                }
            }
        }
        public static void InsertionSort(int[] a)
        {
            int size = a.Length, temp, j;
            for (int i = 1; i < size; i++)
            {
                temp = a[i];
                for (j = i; j > 0 && More(a[j - 1], temp); j--)
                {
                    a[j] = a[j - 1];
                }
                a[j] = temp;
            }
        }
        public static void SelectionSort(int[] a)
        {
            int size = a.Length, minIndex;
            for (int i = 0; i < size - 1; i++)
            {
                minIndex = i;
                for (int j = i + 1; j < size; j++)
                {
                    if (More(a[minIndex], a[j]))
                        minIndex = j;
                }
                Swap(a, i, minIndex);
            }
        }
        public static void MergeSort(int[] a, int left, int right)
        {
            if (left < right)
            {
                //int middle = left + (right - left) / 2;
                int middle = (right + left) / 2;
                MergeSort(a, left, middle);
                MergeSort(a, middle + 1, right);

                merge(a, left, middle, right);
            }

            void merge(int[] arr, int start, int mid, int end)
            {
                int start2 = mid + 1;
                if (arr[mid] <= arr[start2])
                    return;

                while (start <= mid && start2 <= end)
                {
                    if (arr[start] <= arr[start2])
                        start++;
                    else
                    {
                        int value = arr[start2];
                        int index = start2;

                        while (index != start)
                        {
                            arr[index] = arr[index - 1];
                            index--;
                        }
                        arr[start] = value;

                        start++;
                        mid++;
                        start2++;
                    }
                }
            }
        }
        //#region Longer Version Merge Sort
        //public static void MergeSort(int[] a)
        //{
        //    sort(a, 0, a.Length - 1);

        //    void sort(int[] arr, int left, int right)
        //    {
        //        if (left < right)
        //        {
        //            int mid = left + (right - left) / 2;

        //            sort(arr, left, mid);
        //            sort(arr, mid + 1, right);
        //            merge(arr, left, mid, right);
        //        }
        //    }

        //    void merge(int[] arr, int left, int mid, int right)
        //    {
        //        //find sizes of sub arrays
        //        int subSize1 = mid - left + 1;
        //        int subSize2 = right - mid;

        //        //create temp arrays
        //        int[] leftArr = new int[subSize1];
        //        int[] rightArr = new int[subSize2];

        //        //copy data to temp arrays
        //        int i, j;
        //        for (i = 0; i < subSize1; i++)
        //            leftArr[i] = arr[left + i];
        //        for (j = 0; j < subSize2; j++)
        //            rightArr[j] = arr[mid + 1 + j];

        //        i = 0; j = 0;
        //        //merge initial
        //        int k = left;
        //        while (i < subSize1 && j < subSize2)
        //        {
        //            if (leftArr[i] <= rightArr[j])
        //            {
        //                arr[k] = leftArr[i];
        //                i++;
        //            }
        //            else
        //            {
        //                arr[k] = rightArr[j];
        //                j++;
        //            }
        //            k++;
        //        }
        //        //merge left
        //        while (i < subSize1)
        //        {
        //            arr[k] = leftArr[i];
        //            i++;
        //            k++;
        //        }
        //        //merge right
        //        while (j < subSize2)
        //        {
        //            arr[k] = rightArr[j];
        //            j++;
        //            k++;
        //        }
        //    }
        //}
        //#endregion
        public static void QuickSort(int[] a, int lower, int upper)
        {
            if (upper <= lower)
                return;
            int pivot = a[lower];
            int start = lower, stop = upper;
            while (lower < upper)
            {
                while (a[lower] <= pivot && lower < upper)
                {
                    lower++;
                }
                while (a[upper] > pivot && lower <= upper)
                {
                    upper--;
                }
                if (lower < upper)
                {
                    Swap(a, upper, lower);
                }
            }
            Swap(a, upper, start);//upper is the pivot positon
            QuickSort(a, start, upper - 1);//pivot-1 is the upper for left sub array
            QuickSort(a, upper + 1, stop);//pivot+1 is the lower for right sub array
        }

        public static void BucketSort(int[] a, int lowerRange, int upperRange)
        {
            int i, j;
            int size = a.Length;
            int range = upperRange - lowerRange;
            int[] count = new int[range];

            for (i = 0; i < size; i++)
            {
                count[a[i] - lowerRange]++;//ilgili tekrar sayısını arttır
            }

            j = 0;
            for ( i = 0; i < range; i++)
            {
                for (; count[i]>0; (count[i])--)
                {
                    a[j++] = i + lowerRange;
                }
            }
        }
    }
}
