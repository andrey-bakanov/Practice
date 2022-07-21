using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Bloom
{
    internal class BloomTest
    {
        public static void  Test()
        {
            BloomFilter filter = new BloomFilter(1000000, 100000);
            filter.Add("192.168.0.10");

            var resultFalse = filter.NotExists("192.168.0.1");
            var resultTrue = filter.NotExists("192.168.1.1");
            var resultTrue2 = filter.NotExists("192.168.1.0");

            string baseIp = "192.168.0.";
            for (int i = 0; i <= 255; i++)
            { 
                string ip = baseIp + i.ToString();
                Console.WriteLine(ip + " -> " + filter.NotExists(ip));
            }

        }
    }
}
