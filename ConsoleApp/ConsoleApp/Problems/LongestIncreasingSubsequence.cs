using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp.Problems
{
    /// <summary>
    /// https://www.geeksforgeeks.org/longest-increasing-subsequence-dp-3/
    /// </summary>
    internal class LongestIncreasingSubsequence
    {
        public static void Run()
        {

            Console.WriteLine("------------ LongestIncreasingSubsequence ---------------");

            int[] array = new int[] { 10, 2, 3, 2, 7, 4, 9, 3, 1, 3, 7 }; //2379

            int resultLength = 0;
            int[] result = new int[array.Length];

            int innerLength = 0;
            int[] innerResult = new int[array.Length];
            


            for (int i = 0; i < array.Length; i++)
            {                
                int prevMax = 0;
                innerLength = 0;

                for (int j = i; j < array.Length; j++)
                {
                    int inner = array[j];
                    if(inner > prevMax)
                    {
                        prevMax = inner;

                        innerResult[innerLength] = inner;
                        innerLength++;
                    }
                }

                if(innerLength > resultLength)
                {
                    resultLength = innerLength;

                    for(int z = 0; z < result.Length; z++)
                    {
                        result[z] = innerResult[z];
                        innerResult[z] = 0;
                    }
                } 


                Console.WriteLine($"i={i}  lenght=" + innerLength);
            }


            Console.WriteLine($"total length=" + resultLength);
            Console.WriteLine(JsonSerializer.Serialize(result));

        }
    }
}
