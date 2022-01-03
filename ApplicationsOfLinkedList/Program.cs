using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsOfLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            NodeList list = new NodeList();
            list.addHead(3);
            list.addHead(5);
            list.addHead(1);
            list.addHead(4);
            list.addHead(2);

            list.print();

            CircularLinkedList cl = new CircularLinkedList();
            cl.addHead(1);
            cl.addHead(2);
            cl.addHead(3);

            Console.ReadLine();
        }
    }
}
