using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp.Algorithms.WalkGraph
{
    /// <summary>
    /// Для бинарного дерева :
    ///     найти максимальную сумму поддерева
    ///     найти сами узлы с максимальной суммой
    /// </summary>
    internal static class GetMaxBranchSum
    {
        public static void Run()
        {
            BinaryNode<int> root = new BinaryNode<int>(1)
            {
                Left = new BinaryNode<int>(2)
                {
                    Left = new BinaryNode<int>(1)
                    {
                        Left = new BinaryNode<int>(9)
                    },
                    Right = new BinaryNode<int>(7)
                },

                Right = new BinaryNode<int>(9) {
                    Left = new BinaryNode<int>(5)
                    {
                        Left = new BinaryNode<int>(7)
                    },
                    Right = new BinaryNode<int>(2)
                },
                   
            };

            int max = GetMax(root);

            Console.WriteLine($"max={max}");

            List<int> path = new List<int>(5);
            var node = GetPath(root);
            var item = _paths.First();
            Console.WriteLine($"{JsonSerializer.Serialize(node)}");
        }

        private static int GetMax(BinaryNode<int> root)
        {
            

            int left = root.Left != null ? GetMax(root.Left) : 0;
            int right = root.Right != null ?  GetMax(root.Right) : 0;

            return Math.Max(left, right) + root.Data;

        }


        private static Dictionary<BinaryNode<int>, List<BinaryNode<int>>> _paths = new Dictionary<BinaryNode<int>, List<BinaryNode<int>>>();
        private static int GetPath(BinaryNode<int> root)
        {
            var left = root.Left != null ? GetPath(root.Left) : 0;
            var right = root.Right != null ? GetPath(root.Right) : 0;

            _paths[root] = new List<BinaryNode<int>>();
            _paths[root].Add(root);

            if (left > right)
            {
                if (root.Left != null)
                {
                    _paths[root].AddRange(_paths[root.Left]);
                    _paths.Remove(root.Left);
                }
                if(root.Right != null)
                    _paths.Remove(root.Right);

                return (left + root.Data);
            }
            else 
            {
                if (root.Right != null)
                {
                    _paths[root].AddRange(_paths[root.Right]);
                    _paths.Remove(root.Right);
                }

                if(root.Left != null)
                    _paths.Remove(root.Left);

                return ( right + root.Data);
            }
        }
    }
}
