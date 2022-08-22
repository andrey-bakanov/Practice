using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Algorithms.WalkGraph
{
    public class BinaryNode<T>
    {
        public T Data { get; set; }

        public BinaryNode(T data)
        {
            Data = data;    
        }

        public BinaryNode<T> Left { get; set; }


        public BinaryNode<T> Right { get; set; }
    }
}
