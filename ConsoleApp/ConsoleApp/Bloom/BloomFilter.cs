using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Bloom
{
    /// <summary>
    /// https://habr.com/ru/company/otus/blog/541378/
    /// </summary>
    internal class BloomFilter
    {
        private readonly int size;
        private readonly int valuesSetSize;

        private readonly BitArray bitMask;
        private readonly int hashNumbers;

        private SimpleHash hash = new SimpleHash();

        public BloomFilter(int size, int valuesSetSize)
        {
            this.size = size;
            this.valuesSetSize = valuesSetSize;

            this.bitMask = new BitArray(size);
            this.hashNumbers = Convert.ToInt32((this.size / this.valuesSetSize) * Math.Log(2));
        }

        private int Hash(string item, int addon)
        {
            string val = addon.ToString() + item;
            return (int)hash.ComputeDJB2(val,  this.size);
        }

        public void Add(string item)
        {
            for (int i = 0; i < this.hashNumbers; i++)
            {
                int index = Hash(item, i);
                this.bitMask[index] = true;
            }
        }

        public bool NotExists(string item)
        {
            for (int i = 0; i < this.hashNumbers; i++)
            {
                int index = Hash(item, i);
                if(!this.bitMask[index])
                {
                    return true;
                };
            }

            return false;
        }
    }
}
