using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Algorithms.Lists
{
    internal class LinkedNode<T>
    {
        public T Value { get; set; }
        public LinkedNode<T> Next { get; set; }
    }
}
