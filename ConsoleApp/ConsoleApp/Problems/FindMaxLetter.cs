using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Problems
{
    internal static class FindMaxLetter
    {
        public static void Run()
        {
            string source = "AAAGGTKKLLLTMMTTTLSSS"; // -> T 5

            Stopwatch sw = Stopwatch.StartNew();
            string result = Find(source);
            sw.Stop();
            Console.WriteLine(sw.Elapsed + ":" + source + " -> " + result);
        }


        private static string Find(string source)
        {

            Dictionary<char,int> keyValuePairs = new Dictionary<char,int>();
            char resultChar = source[0];
            int resultCount = 1;

            for (int i = 1; i < source.Length; i++)
            {
                var currentChar = source[i];

                if (keyValuePairs.ContainsKey(currentChar))
                {
                    var count = keyValuePairs[currentChar];
                    count++;
                    keyValuePairs[currentChar] = count;

                    if(count > resultCount)
                    {
                        resultCount = count;
                        resultChar = source[i];
                    }

                }
                else
                    keyValuePairs[currentChar] = 1;

            }

            return $"{resultChar} {resultCount}";
        }
    }
}
