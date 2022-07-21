using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Bloom
{
    public class SimpleHash
    {
        [Benchmark]
        [Arguments("test", 20)]
        [Arguments("длинный текст", 20)]
        [Arguments("очень длинный текст", 20)]
        [Arguments("невозможно очень длинный текст", 20)]
        public uint ComputeDJB2(string s, int hashSize)
        {
            uint hash = 5381;
            foreach (char x in s)
                hash = ((hash << 5) + hash) + (uint)x;

            return  hash % (uint)hashSize;
        }

        public uint ComputeSDBM(string s, int hashSize)
        {
            uint hash = 0;
            foreach (char x in s)
                hash = ((hash << 6) + (hash << 16)) + (uint)x - hash;

            return hash % (uint)hashSize;
        }

        public uint ComputeLoseLose(string s, int hashSize)
        {
            uint hash = 0;
            foreach (char x in s)
                hash += (uint)x;

            return hash % (uint)hashSize;
        }
    }
}
