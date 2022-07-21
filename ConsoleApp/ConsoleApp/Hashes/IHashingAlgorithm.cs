using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Hashes
{
    namespace HashTableHashing
    {
        public interface IHashAlgorithm
        {
            UInt32 Hash(Byte[] data);
        }
        public interface ISeededHashAlgorithm : IHashAlgorithm
        {
            UInt32 Hash(Byte[] data, UInt32 seed);
        }
    }
}
