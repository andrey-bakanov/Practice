using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Algorithms.Lists
{
    internal class LinkedList<T> : IList<LinkedNode<T>>
    {
        private int _count = 0;

        private LinkedNode<T> _head;

        private LinkedNode<T> _last;

        public LinkedNode<T> this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Count =>  _count;

        public bool IsReadOnly => false;

        public void Add(LinkedNode<T> item)
        {
            if(_head == null)
            {
                _head = item;
                _last = item;
            }
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(LinkedNode<T> item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(LinkedNode<T>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<LinkedNode<T>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(LinkedNode<T> item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, LinkedNode<T> item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(LinkedNode<T> item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
