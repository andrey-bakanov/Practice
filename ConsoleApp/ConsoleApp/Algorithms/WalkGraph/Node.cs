using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Algorithms.WalkGraph
{
    public class Node<T>
    {
        public T Data { get; set; }

        public Node(T data)
        {
            Data = data;    
        }

        public List<Node<T>> Children { get; set; } = new List<Node<T>>();

    }
}
