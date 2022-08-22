using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Algorithms.WalkGraph
{
    /// <summary>
    /// Depth-First Search
    /// </summary>
    internal static class DFS
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

            DoDFS2(root);
        }

        private static void DoDFS(Node<int> root)
        {
            Console.WriteLine(root.Data);
            foreach (Node<int> node in root.Children)
            {
                DoDFS(node);
            }
        }

        private static void DoDFS2(Node<int> root)
        {
            Stack<Node<int>> queue = new Stack<Node<int>>();
            queue.Push(root);

            while (queue.Count > 0)
            {
                var node = queue.Pop();
                Console.WriteLine(node.Data);

                foreach (var item in node.Children)
                {
                    queue.Push(item);
                }
            }
        }
    }
}
