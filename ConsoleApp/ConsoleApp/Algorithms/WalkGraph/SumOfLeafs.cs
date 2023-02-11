using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Algorithms.WalkGraph
{
    internal static class SumOfLeafs
    {
        internal static void Run()
        {
            Console.WriteLine("============= SumOfLeafs ===================");

            BinaryNode<int> root = new BinaryNode<int>(3)
            {
                Left = new BinaryNode<int>(3)
                {
                    Left = new BinaryNode<int>(5),
                    Right = new BinaryNode<int>(4)
                },
                Right = new BinaryNode<int>(7)
                {
                    Left = new BinaryNode<int>(6)
                }

            };


            int sum = GetLeafsSum2(root); //15

            Console.WriteLine("sum = " +sum);

        }

        private static int GetLeafsSum(BinaryNode<int> root)
        {
            int result = 0;
            if(root == null)
                return result;

            Stack<BinaryNode<int>> stack = new Stack<BinaryNode<int>>(10);
            stack.Push(root);
            while (stack.Count > 0)
            {
                var element = stack.Pop();

                if (element.Left == null && element.Right == null)
                    result += element.Data;

                if(element.Left != null)
                    stack.Push(element.Left);

                if(element.Right != null)
                    stack.Push(element.Right);

            }

            return result;
        }


        private static int GetLeafsSum2(BinaryNode<int> node )
        {
            int result = 0;
            if (node == null)
                return result;

            if (node.Left == null && node.Right == null)
                result += node.Data;


            int resultLeft = GetLeafsSum2(node.Left);
            int resultRight = GetLeafsSum2(node.Right);


            return result+ resultLeft + resultRight;
        }
    }
}
