using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Tasks
{
    internal class MergeLists
    {
        public void Execute()
        {

            LinkedList<int> list1 = new LinkedList<int>();
            var node11 = list1.AddFirst(1);
            var node12 = list1.AddAfter(node11, 2);
            list1.AddAfter(node12, 3);

            LinkedList<int> list2 = new LinkedList<int>();
            var node21 = list2.AddFirst(1);
            var node22 = list2.AddAfter(node21, 2);
            list2.AddAfter(node22, 3);

            //we have 2 sorted linked list - merge them

            LinkedList<int> result = new LinkedList<int>();
            var current = result.AddFirst(node11.Value);

            var current1 = node11.Next;
            var current2 = node21;



            while (true)
            {
                if (current1 == null || current2 == null)
                {
                    break;
                }

                if (current1.Value < current2.Value)
                {
                    current = result.AddAfter(current, current1.Value);
                    current1 = current1.Next;
                }
                else if (current1.Value > current2.Value)
                {
                    current = result.AddAfter(current, current2.Value);
                    current2 = current2.Next;
                }
                else
                {
                    current = result.AddAfter(current, current1.Value);
                    current1 = current1.Next;

                    current = result.AddAfter(current, current2.Value);
                    current2 = current2.Next;
                }


            }

            if(current1 != null)
            {
                while (current1 != null)
                {
                    Console.WriteLine(current1.Value);
                    current1 = current1.Next;
                }
            }

            if (current2 != null)
            {
                while (current2 != null)
                {
                    Console.WriteLine(current2.Value);
                    current2 = current2.Next;
                }
            }


            var node = result.First;
            while(node != null)
            {
                Console.WriteLine(node.Value);
                node = node.Next;
            }

        }
    }
}
