using ConsoleApp.Algorithms.WalkGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Problems.Easy
{
    internal class BinaryTreeComparer
    {
        /*
        OZON
        compare two binary tree

            1               1
        2       3       2       3

        true - if binary tree is identical
        otherwise - false

         */

        public void Execute()
        {
            Console.WriteLine("============ BinaryTreeComparer =============");
            BinaryNode<int> tree1 = new BinaryNode<int>(1)
            {
                Left = new BinaryNode<int>(2),
                Right = new BinaryNode<int>(3),
            };

            BinaryNode<int> tree2 = new BinaryNode<int>(1)
            {
                Left = new BinaryNode<int>(2),
                Right = new BinaryNode<int>(3),
            };

            bool result = IsEquals(tree1, tree2);

            Console.WriteLine($"BinaryTreeComparer= {result}");
        }

        private bool IsEquals(BinaryNode<int> t1, BinaryNode<int> t2)
        {
            if (t1 == null && t2 == null)
                return true;

            if((t1 == null && t2 != null) || (t1 != null && t2 == null))
                return false;

            if ( t1.Data == t2.Data && IsEquals(t1.Left, t2.Left) && IsEquals(t1.Right, t2.Right) )
                return true;

            return false;
        }
    }
}
