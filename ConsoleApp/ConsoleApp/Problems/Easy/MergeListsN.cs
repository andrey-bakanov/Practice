using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Problems.Easy
{
    /*
    OZON
    we have a number of linked lists [1,2,3,5] [1] [1,6]

    write a function to merge all to one sorted list

     */
    internal class MergeListsN
    {
        public void Execute()
        {

            LinkedList<int> list1 = new LinkedList<int>();
            list1.AddLast(1);
            list1.AddLast(2);
            list1.AddLast(3);

            LinkedList<int> list2 = new LinkedList<int>();
            list2.AddLast(1);
            list2.AddLast(2);
            list2.AddLast(3);

            LinkedList<int> list3 = new LinkedList<int>();
            list3.AddLast(2);
            list3.AddLast(6);

            //we have 2 sorted linked list - merge them

            var input = new List<LinkedList<int>>
            {
                list1, list2, list3
            };

            var result = Do(input);

            var node = result.First;
            while (node != null)
            {
                Console.WriteLine(node.Value);
                node = node.Next;
            }
        }

        private LinkedList<int> Do(List<LinkedList<int>> lists)
        {
            LinkedList<int> result = new LinkedList<int>();
            if(lists == null || lists.Count == 0)
            {
                return result;
            }

            PriorityQueue<int,int> queue = new System.Collections.Generic.PriorityQueue<int,int>();

            LinkedListNode<int>[] currents = new LinkedListNode<int>[lists.Count];

            bool hasNoneEmptyLists = false;
            for(int i = 0; i < lists.Count; i++)
            {
                var list = lists[i];
                if (list.Count > 0)
                {
                    hasNoneEmptyLists = true;
                    currents[i] = list.First;
                }
            }

            if(!hasNoneEmptyLists)
            {
                return result;
            }

            bool hasNodes = true;
            while(hasNodes)
            {
                hasNodes = false;
                for (int i = 0; i < currents.Length; i++)
                {
                    var currentNode = currents[i];
                    if(currentNode == null)
                    {
                        continue;
                    }

                    queue.Enqueue(currentNode.Value, currentNode.Value);
                    currents[i] = currentNode.Next;

                    hasNodes = true;
                }

            }

            while(queue.Count > 0)
            {
                result.AddLast(queue.Dequeue());
            }

            return result;
        }
    }
}
