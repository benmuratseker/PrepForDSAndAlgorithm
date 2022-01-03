using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsOfStack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack s = new Stack();
            s.Push(1);
            s.Push(2);
            s.Push(3);
            s.Print();
            //Console.WriteLine(s.Pop()+" pop");
            //s.Print();
            Console.WriteLine("----------------------------------------------");
            StackLL sL = new StackLL();
            sL.Push(11);
            sL.Push(12);
            sL.Push(13);
            sL.Print();
            Console.ReadLine();
        }
    }
}
