using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsOfQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue q = new Queue();
            q.Add(4);
            q.Add(1);
            q.Add(7);
            q.Print();
            Console.WriteLine("-----------------------------------------");
            QueueLL ql = new QueueLL();
            ql.Add(5);
            ql.Add(48);
            ql.Add(25);
            ql.Print();
            Console.ReadLine();
        }
    }
}
