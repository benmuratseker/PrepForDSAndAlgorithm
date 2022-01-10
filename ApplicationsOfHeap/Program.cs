using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsOfHeap
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[] { 1, 9, 6, 7, 8, 0, 2, 4, 5, 3 };
            Heap hp = new Heap(a, false);
            hp.add(100);
            
            while (hp.isEmpty() == false)
            {
                Console.Write(hp.remove() + " ");
            }
            Console.ReadLine();
        }
    }
}
