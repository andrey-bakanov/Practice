using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp.Problems
{
    internal class MaxSubArraySumOfSizeN
    {
        //[-2, 2, 5, -11, 6] -> N=2 =>  2,5 
        //[-2, 2, 5, -11, 6, 2] -> N=3 =>  -2,2,5 

        internal static void Run()
        {
            Console.WriteLine("=================== MaxSubArraySumOfSizeN ==================");

            int N = 2;
            int[] array = new int[] { -2, 1, 2, 5, -11, 6 };//->2,5

            int resultIndex = FindStartIndex(array, N);


            int[] resultArray = array.Skip(resultIndex).Take(N).ToArray();
            Console.WriteLine(JsonSerializer.Serialize(resultArray ) );


            int N2 = 3;
            int[] array2 = new int[] { -2, 2, 5, -11, 6, 2 };//->-2,2,5

            int resultIndex2 = FindStartIndex(array2, N2);


            int[] resultArray2 = array2.Skip(resultIndex2).Take(N2).ToArray();
            Console.WriteLine(JsonSerializer.Serialize(resultArray2));
        }

        private static int FindStartIndex(int[] array, int N)
        {
            //corner cases ???
            int resultIndex = 0;
            int result = 0;
            int currentSum= 0;

            for (int i = 0; i < N; i++)
            {
                currentSum+=array[i];
                result+=array[i];
            }

            for (int i = 1; i < array.Length - N; i++)
            {

                int lastIndex = i + N - 1;

                currentSum += array[lastIndex];
                currentSum -= array[i - 1];


                if (currentSum > result)
                {
                    result = currentSum;
                    resultIndex = i;
                }
            }
            return resultIndex;
        }
    }
}
