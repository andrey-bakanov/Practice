using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Algorithms.WalkGraph
{
    /// <summary>
    /// Breadth-First Search
    /// </summary>
    internal static class BFS
    {

        public static void Run()
        {
            Node<int> root = new Node<int>(0)
            {
                Children = new List<Node<int>> { 
                    new Node<int>(1){
                        Children = new List<Node<int>> {
                            new Node<int>(4),
                            new Node<int>(5),
                            new Node<int>(6)
                        }
                    },
                    new Node<int>(2){
                        Children = new List<Node<int>> {
                            new Node<int>(7),
                            new Node<int>(8),
                            new Node<int>(9)
                        }
                    },
                    new Node<int>(3){
                        Children = new List<Node<int>> {
                            new Node<int>(10),
                            new Node<int>(11),
                            new Node<int>(12)
                        }
                    }
                }
            };

            DoBFS(root);
        }

        private static void DoBFS(Node<int> root)
        {
            Queue<Node<int>> queue = new Queue<Node<int>>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            { 
                var node = queue.Dequeue();
                Console.WriteLine(node.Data);

                foreach (var item in node.Children)
                {
                    queue.Enqueue(item);
                }
            }


        }
    }
}
