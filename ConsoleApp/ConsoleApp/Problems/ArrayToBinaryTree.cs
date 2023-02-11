using ConsoleApp.Algorithms.WalkGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp.Problems
{
    internal static class ArrayToBinaryTree
    {
        internal static void Run()
        {

            Console.WriteLine("=================== ArrayToBinaryTree =====================");

            int[] array = new int[] {1, 2, 3, 6, 12, 8, 4, 8, 4, 9, 8, 14, 7, 67};

            BinaryNode<int> root = ToTree(array);

            JsonSerializerOptions opt = new JsonSerializerOptions();
            opt.WriteIndented = true;


            Console.WriteLine(JsonSerializer.Serialize(root, opt));
        }

        private static BinaryNode<int> ToTree(int[] array)
        {


            int baseIndex = array.Length / 2;
            BinaryNode<int> root = new BinaryNode<int>(array[baseIndex]);

            root.Left = ToTree(0,           baseIndex-1,    array, root);
            root.Right = ToTree(baseIndex+1, array.Length-1, array, root);

            return root;

        }

        private static BinaryNode<int> ToTree(int start, int end, int[] array, BinaryNode<int> parent)
        {
            if(start > end  || parent == null)
            {
                return null;
            }

            int baseIndex = (end + start)/ 2;
            var currentNode = new BinaryNode<int>(array[baseIndex]);

            currentNode.Left = ToTree(start, baseIndex - 1, array, currentNode);
            currentNode.Right = ToTree(baseIndex + 1, end, array, currentNode);

            return currentNode;
        }

    }
}
